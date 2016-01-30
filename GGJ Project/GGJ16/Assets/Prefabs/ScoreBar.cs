using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBar : MonoBehaviour 
{
	private ScoreManager _scoreManager;
	private Slider _slider;

	void Start()
	{
		_slider = gameObject.GetComponent<Slider>();
        _scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
	}

	// Update is called once per frame
	void Update () 
	{
		_slider.value = Mathf.Lerp(_slider.value, _scoreManager.GetScorePercentage(), Time.deltaTime * 0.5f);
	}
}
