using UnityEngine;
using System.Collections;

public class FemaleLookAt : MonoBehaviour
{
    public Vector3 player1pos;
    public Vector3 player2pos;

    private Vector3 startRotation;

    private ScoreManager scoreManager;
    void Awake()
    {
        player1pos = GameObject.FindWithTag("Player1").transform.position;
        player2pos = GameObject.FindWithTag("Player2").transform.position;
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        startRotation = transform.eulerAngles;
    }
	
    void Update ()
    {
	    if(scoreManager.currentScore == 0)
        {
            transform.eulerAngles = startRotation;
        }
        else if(scoreManager.currentScore < 0)
        {
            transform.LookAt(player1pos);
            transform.eulerAngles = new Vector3(startRotation.x, transform.eulerAngles.y, startRotation.z);
        }
        else
        {
            transform.LookAt(player2pos);
            transform.eulerAngles = new Vector3(startRotation.x, transform.eulerAngles.y, startRotation.z);
        }
	}
}
