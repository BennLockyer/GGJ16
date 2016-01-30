using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GenerateCombos : MonoBehaviour
{
    //VARIABLES
    //Really should have used a struct with two instances, oh well.
    //Combos
    private List<KeyCode> P1Combo;
    private List<KeyCode> P2Combo;
    //Input list
    public List<KeyCode> P1Inputs;
    public List<KeyCode> P2Inputs;
    //Number of elements in combos
    private int p1KeyCount;
    private int p2KeyCount;
    //Range of elements in combos
    private int p1KeyRange;
    private int p2KeyRange;
    //Difficulty level for players
    private int p1Difficulty;
    private int p2Difficulty;
    //Keyboard?
    public bool p1Keyboard;
    public bool p2Keyboard;

    ScoreManager score;

    void Awake()
    {
        score = GetComponent<ScoreManager>();

        Init();
    }

    public void Init()
    {
        //p1 Inputs
        P1Inputs = new List<KeyCode>();
        P1Inputs.Add(KeyCode.Z);
        P1Inputs.Add(KeyCode.S);
        P1Inputs.Add(KeyCode.A);
        P1Inputs.Add(KeyCode.W);
        P1Inputs.Add(KeyCode.Alpha1);
        P1Inputs.Add(KeyCode.Alpha2);
        //Joystick
        P1Inputs.Add(KeyCode.Joystick1Button0);
        P1Inputs.Add(KeyCode.Joystick1Button1);
        P1Inputs.Add(KeyCode.Joystick1Button2);
        P1Inputs.Add(KeyCode.Joystick1Button3);
        P1Inputs.Add(KeyCode.Joystick1Button4);
        P1Inputs.Add(KeyCode.Joystick1Button5);

        //p2 Inputs
        P2Inputs = new List<KeyCode>();
        P2Inputs.Add(KeyCode.M);
        P2Inputs.Add(KeyCode.K);
        P2Inputs.Add(KeyCode.J);
        P2Inputs.Add(KeyCode.I);
        P2Inputs.Add(KeyCode.Alpha8);
        P2Inputs.Add(KeyCode.Alpha9);
        //Joystick
        P2Inputs.Add(KeyCode.Joystick2Button0);
        P2Inputs.Add(KeyCode.Joystick2Button1);
        P2Inputs.Add(KeyCode.Joystick2Button2);
        P2Inputs.Add(KeyCode.Joystick2Button3);
        P2Inputs.Add(KeyCode.Joystick2Button4);
        P2Inputs.Add(KeyCode.Joystick2Button5);

        ConfigureDifficulty();
    }

    // Use this for initialization
    public List<KeyCode> Generate (int player)
    {
        ConfigureDifficulty();

        if (player == 0)
        {
            //Player one combo generation
            P1Combo = new List<KeyCode>();
            int shift = p1Keyboard ? 0 : 6;
            for (int i = 0; i < p1KeyCount; i++)
            {
                P1Combo.Add(P1Inputs[UnityEngine.Random.Range(shift, p1KeyRange + shift)]);
            }
            //Pass the combo to the player
            return P1Combo;
        }
        else
        {
            //Player one combo generation
            P2Combo = new List<KeyCode>();
            int shift = p2Keyboard ? 0 : 6;
            for (int i = 0; i < p2KeyCount; i++)
            {
                P2Combo.Add(P2Inputs[UnityEngine.Random.Range(shift, p2KeyRange + shift)]);
            }
            //Pass the combo to the player
            return P2Combo;
        }
	}

    private void ConfigureDifficulty()
    {
        //get the range from the score controller
        float upperLimit = score.targetScore;
        float lowerLimit = -score.targetScore;
        float div = (score.targetScore * 2) * 0.2f;
        //and the current score
        float currentScore = score.currentScore;

        //compare the current score to divisions of 5 within the score range, shift difficulties accordingly
        if(currentScore < lowerLimit + div)
        {
            Debug.Log("lowest");
            p1Difficulty = 1;
            p2Difficulty = 5;

            p1KeyCount = 4;
            p1KeyRange = 4;

            p2KeyCount = 8;
            p2KeyRange = 6;
        }
        else if(currentScore < lowerLimit + (div * 2))
        {
            Debug.Log("low");
            p1Difficulty = 2;
            p2Difficulty = 4;

            p1KeyCount = 5;
            p1KeyRange = 4;

            p2KeyCount = 7;
            p2KeyRange = 4;
        }
        else if(currentScore < lowerLimit + (div * 3))
        {
            Debug.Log("mid");
            p1Difficulty = 3;
            p2Difficulty = 3;

            p1KeyCount = 6;
            p1KeyRange = 4;

            p2KeyCount = 6;
            p2KeyRange = 4;
        }
        else if (currentScore < lowerLimit + (div * 4))
        {
            Debug.Log("high");
            p1Difficulty = 4;
            p2Difficulty = 2;

            p1KeyCount = 7;
            p1KeyRange = 4;

            p2KeyCount = 5;
            p2KeyRange = 4;
        }
        else
        {
            Debug.Log("highest");
            p1Difficulty = 5;
            p2Difficulty = 1;

            p1KeyCount = 8;
            p1KeyRange = 6;

            p2KeyCount = 4;
            p2KeyRange = 4;
        }
    }
}
