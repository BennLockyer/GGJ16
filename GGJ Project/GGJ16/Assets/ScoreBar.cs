using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBar : MonoBehaviour 
{
	[SerializeField]
	private ScoreManager _scoreManager;
	private Slider _slider;

	void Start()
	{
		_slider = gameObject.GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () 
	{
		_slider.value = _scoreManager.GetScorePercentage();
	}
}
