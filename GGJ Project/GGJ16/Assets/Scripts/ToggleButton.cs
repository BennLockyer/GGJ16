using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// A general toggle button object
// How to: Attach this to a button

[RequireComponent(typeof(Button), typeof(Image))]
public class ToggleButton : MonoBehaviour
{
	public enum ToggleType 
	{
		TOGGLE_STRING,
		TOGGLE_IMAGE
	};
	public ToggleType type;
	public bool bToggle;

	public Sprite 	falseImage;
	public Sprite 	trueImage;

	public string 	falseText;
	public string 	trueText;

	private Image 	btnImage;
	private Text 	btnText;

	void Start ()
	{
		btnText = gameObject.GetComponentInChildren<Text>();
		if(btnText == null) 
			Debug.Log("Text component not found in children of " + gameObject.ToString());

		btnImage = gameObject.GetComponent<Image>();
		if(btnImage == null)
			Debug.Log("Image component not found in " + gameObject.ToString());
	}

	void Update ()
	{
		switch(type)
		{
			case ToggleType.TOGGLE_IMAGE:
				btnText.text = "";
				btnImage.sprite = (bToggle) ? trueImage : falseImage;
			break;
			case ToggleType.TOGGLE_STRING:
				btnText.text = (bToggle) ? trueText : falseText;
			break;
			default:
			break;
		}
	}

	public void Toggle()
	{
		bToggle = !bToggle;
	}
}
