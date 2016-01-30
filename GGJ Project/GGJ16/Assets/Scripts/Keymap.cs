using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Intended for the purpose of Mapping keycodes to UI Images to be displayed

public class Keymap : MonoBehaviour {
	[SerializeField]
	public Dictionary<KeyCode, string> _KeyMap;
}
