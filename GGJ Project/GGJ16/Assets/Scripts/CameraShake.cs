﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	private Vector3 originPosition;
	private Vector3 startPosition;
	
	private float shake_decay;
	private float shake_intensity;
	
	private bool isShaking;

    private float shakeTime;
    private bool isPaused;
	
	void Update()
	{
        
		if(shake_intensity > 0)
		{
            if (isPaused)
            {
                Debug.Log("PAUSED");
                if (Time.unscaledTime >= shakeTime + 1.0f)
                {
                    Debug.Log("Resetting time scale");
                    isPaused = false;
                    Time.timeScale = 1;
                }
            }
            else
            {
                //			Vector3 shake = originPosition + Random.insideUnitSphere * shake_intensity;
                transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
                //			transform.position += (shake - originPosition);
                shake_intensity -= shake_decay;
            }
		}
		else
		{
			if(isShaking)
			{
				isShaking = false;
//				transform.position = startPosition;
			}
		}
	}
	
	public void SmallShake()
	{
		StartCoroutine(Shake (0.01f,0.05f));
	}

    public void MediumShake()
    {
        StartCoroutine(Shake(0.01f, 0.1f));
    }
	
	public void BigShake()
	{
		StartCoroutine(Shake (0.01f,0.2f));
	}
	
	IEnumerator Shake(float decay, float intensity)
	{
		yield return new WaitForEndOfFrame();
		originPosition = transform.position;
		shake_intensity = intensity;
		shake_decay = decay;
		isShaking = true;
        isPaused = true;
        shakeTime = Time.time;
        Time.timeScale = 0;
	}
}
