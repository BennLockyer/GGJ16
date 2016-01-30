using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Intended for the purpose of Mapping keycodes to UI Images to be displayed

// Because Dictionary does not work in the inspector - a list of class will be used instead
public class Keymap : MonoBehaviour {
	[SerializeField]
	private List<KeyCode> keyCodeList;
	[SerializeField]
	private List<Sprite> spritesList;

	public Sprite GetSprite(KeyCode kc)
	{
		int index = keyCodeList.IndexOf(kc);
		if(index < 0)
		{
			Debug.LogError("Cannot find Keycode: " + kc.ToString() + " in list");
			return null;
		}

		Sprite outSprite = null;
		if(spritesList[index] != null)
		{
			outSprite = spritesList[index];
		}
		else
			Debug.LogError("Cannot find sprite at index: " + index);

		return outSprite;
	}

	public bool HaveKey(KeyCode kc)
	{
		int index = keyCodeList.IndexOf(kc);
		if(index < 0)
			return false;
		return true;
	}
}