using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{
	public bool bSFX;
	public bool bMusic;
	
	public int numberOfAudioSources;
	public int numberOfPrioritySources;
	
	public AudioClip[] sfx;
	public AudioClip[] music;
	
	//public AudioMixer musicMaster;
	//public AudioMixer sfxMaster;
	
	//public AudioMixerGroup[] mixers;
	
	private List<AudioSource> audioSources = new List<AudioSource>();
	private List<AudioSource> prioritySources = new List<AudioSource>();
	private AudioSource musicSource;
	
	private int currentSource = 0;
	private int currentPriority = 1;

	// Use this for initialization
	void Awake () 
	{
		//get reference to the audio manager
		musicSource = GetComponent<AudioSource> ();

		//determine players saved settings
		bSFX = bool.Parse(PlayerPrefs.GetString ("bSFX", "true"));
		bMusic = bool.Parse(PlayerPrefs.GetString ("bMusic", "true"));
		Debug.Log ("Sfx is " + bSFX + ". Music is " + bMusic);
		

		//Find the total number of sources to be created
		int totalSources = numberOfAudioSources + numberOfPrioritySources;
		//Create audio sources
		for(int x = 0; x < totalSources; ++x)
		{
			//The object will need a name
			string name = "";
			//So the name is based on whether it's normal or priority
			if(x < numberOfAudioSources)
				name = "AudioSource";
			else
				name = "PrioritySource";
			//Create the object (with a name)
			GameObject a = new GameObject(name);
			//Create audiosource component, and get reference to it
			AudioSource au = a.AddComponent<AudioSource>();
			//Set the objects parent to the audio manager
			a.transform.parent = transform;
			
			//Add the audio source to the right list
			if(x < numberOfAudioSources)
				audioSources.Add(au);
			else
				prioritySources.Add(au);
		}

        PlayMusic(0);
	}
	
	void Start()
	{
		if(bMusic)
			ToggleMusic(bMusic);
		if(bSFX)
			ToggleSFX(bSFX);
	}

	public void PlaySFX(int index, bool priority, float pitch)
	{
		if(index >= sfx.Length)
		{
			Debug.LogWarning("SOUND " + index.ToString() + " DOES NOT EXIST\nARRAY IS TOO SHORT");
		}
		else if(sfx[index] == null)
		{
			Debug.LogWarning("SOUND " + index.ToString() + " DOES NOT EXIST\nNO SOUND FILE IN THIS SLOT");
		}
		else if(!priority)
		{
			//if(mixer >= mixers.Length)
			//	Debug.LogWarning("MIXER " + mixer.ToString() + "DOES NOT EXIST\nARRAY IS TOO SHROT");
			//else
			//	audioSources[currentSource].outputAudioMixerGroup = mixers[mixer];
				
			//set the audio clip basd on index.
			audioSources[currentSource].clip = sfx [index];
            audioSources[currentSource].pitch = pitch;
			//play the clip
			audioSources[currentSource].Play ();
			//Move to our next source
			++currentSource;
			//If our count is too high, reset it
			if(currentSource == audioSources.Count)
				currentSource = 0;
		}
		else
		{
			if(index == 33)
			{
				//prioritySources[0].outputAudioMixerGroup = mixers[1];
				prioritySources[0].clip = sfx[33];
				prioritySources[0].Play ();
			}
			else
			{
				//if(mixer >= mixers.Length)
				//	Debug.LogWarning("MIXER " + mixer.ToString() + " DOES NOT EXIST\nARRAY IS TOO SHROT YOU ONLY HAVE " + mixers.Length.ToString() + " MIXERS");
				//else
				///	prioritySources[currentPriority].outputAudioMixerGroup = mixers[mixer];
				//set the audio clip basd on index.
				prioritySources[currentPriority].clip = sfx [index];
                prioritySources[currentPriority].pitch = pitch;
				//play the clip
				prioritySources[currentPriority].Play ();
				//Move to our next source
				++currentPriority;
				//If our count is too high, reset it
				if(currentPriority == prioritySources.Count)
					currentPriority = 1;
			}
		}
	}

	public void PlayMusic(int index)
	{
		if(music[index] != null)
		{
			if(musicSource.clip == music[index])
				return;
			bool willLoop = false;
			if(index < 10 || index == 12)
			{
				willLoop = true;
			}
			else
			{
				willLoop = false;
			}
			StartCoroutine(PlayingMusic(music[index],willLoop));
			
		}
		else
		{
			StopMusic();
		}
	}
	
	public void PlayMusicDelay(float wait, int index)
	{
		StartCoroutine(MusicDelay(wait,index));
	}
	
	public void PlaySfxDelay(float wait, int index, bool priority, int mixer)
	{
		StartCoroutine(SfxDelay(wait,index,priority,mixer));
	}
	
	IEnumerator SfxDelay(float wait, int index, bool priority, int mixer)
	{
		yield return new WaitForSeconds(wait);
		PlaySFX(index,priority,mixer);
	}
	
	IEnumerator PlayingMusic(AudioClip song, bool loop)
	{
		bool isPlaying = false;
		if(musicSource.volume > 0)
		{
			isPlaying = true;
			for(int x = 0; x < 4; ++x)
			{
				musicSource.volume -= 0.1f;
				yield return new WaitForSeconds(0.05f);
			}
		}
		
		musicSource.clip = song;
		musicSource.Play();
		musicSource.loop = loop;
		if(isPlaying)
			musicSource.volume = 0.4f;
	}
	
	IEnumerator MusicDelay(float wait, int index)
	{
		yield return new WaitForSeconds(wait);
		PlayMusic(index);
	}
	//Toggle sfx
	public void ToggleSFX(bool sfxIsOn)
	{
		bSFX = sfxIsOn;

		//save bSFX... do so by converting the bool into a string of either true or false (since bools cannot be saved)
		if (bSFX)
		{
			StopCoroutine("FadeSfx");
			//sfxMaster.SetFloat("volume",0.0f);
			PlayerPrefs.SetString ("bSFX", "true");
			PlaySFX(0,false,0);
		}
		else
		{
//			sfxMaster.SetFloat("volume",-80.0f);
			StartCoroutine("FadeSfx");
			PlayerPrefs.SetString ("bSFX", "false");
		}
	}
	
	//Toggle the music
	public void ToggleMusic(bool musicIsOn)
	{
		bMusic = musicIsOn;
		if(bMusic)
		{
			StopCoroutine("FadeMusic");
			//musicMaster.SetFloat("volume",0.0f);
			PlayerPrefs.SetString ("bMusic", "true");
		}
		else
		{
//			musicMaster.SetFloat("volume",-80.0f);
			StartCoroutine("FadeMusic");
			PlayerPrefs.SetString ("bMusic", "false");
		}
	}
	
	IEnumerator FadeSfx()
	{
		for(int x = 0; x < 81; ++x)
		{
			//sfxMaster.SetFloat("volume",-x);
			yield return new WaitForSeconds(0.01f);
		}
	}
	
	IEnumerator FadeMusic()
	{
		for(int x = 0; x < 81; ++x)
		{
			//musicMaster.SetFloat("volume",-x);
			yield return new WaitForSeconds(0.01f);
		}
	}
	public void StopMusic()
	{
		musicSource.Stop();
	}
}
