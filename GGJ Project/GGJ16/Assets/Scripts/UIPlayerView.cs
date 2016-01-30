using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Intended to display Key Combo and Player Score

public class UIPlayerView : MonoBehaviour 
{
	[SerializeField]
	private SpiderCombo playerCombo;
	[SerializeField]
	private GameObject keyDisplay;
	private Text keyDisplayText;

	private GameObject keyComboContainer;
	private ObjectPool singleComboPool;

	void Start() 
	{
		singleComboPool = GameObject.Find("SingleComboPool").GetComponent<ObjectPool>();
		keyComboContainer = transform.FindChild("ComboPanel").gameObject;
	}

	void Update()
	{
		DisplayCombo();
	}

	void DisplayCombo()
	{
		KeyCode[] keyCombo = playerCombo.combo.ToArray();

		for(int i = 0; i < keyComboContainer.transform.childCount; i++) 
		{
			GameObject obj = keyComboContainer.transform.GetChild(i).gameObject;
			obj.SetActive(false);
		}

		for(int i = 0; i < keyCombo.Length; i++) 
		{
			GameObject obj = singleComboPool.GetAvailableObject();
			obj.transform.SetParent(keyComboContainer.transform);
			obj.SetActive(true);

			obj.GetComponentInChildren<Text>().text = keyCombo[i].ToString();
		}
	}
}
