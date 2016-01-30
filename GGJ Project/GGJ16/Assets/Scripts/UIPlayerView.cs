using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Intended to display Key Combo and Player Score

public class UIPlayerView : MonoBehaviour 
{
	[SerializeField]
	private int player;

	[SerializeField]
	private SpiderCombo playerCombo;
	[SerializeField]
	private GameObject keyDisplay;
	private Text keyDisplayText;

	private GameObject keyComboContainer;
	private ObjectPool singleComboPool;

	private GameObject scoreBar;

	[SerializeField]
	private ScoreManager scoreManager;

	void Start() 
	{
		singleComboPool = GameObject.Find("SingleComboPool").GetComponent<ObjectPool>();
		scoreBar = transform.FindChild("ScoreBar").gameObject;
		keyComboContainer = transform.FindChild("ComboPanel").gameObject;
	}

	void Update()
	{
		DisplayCombo();
		UpdateScoreBar();
	}

	void UpdateScoreBar()
	{
		Debug.Log("Player " + player + " score: " + scoreManager.GetScorePercentage(player));
		scoreBar.GetComponent<Slider>().value = scoreManager.GetScorePercentage(player);
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
