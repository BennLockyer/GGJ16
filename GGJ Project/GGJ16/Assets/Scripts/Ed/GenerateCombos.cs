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
    //which controller is which player?
    public bool[] p1Controller;
    public bool[] p2Controller;
    //Number of elements in combos
    private int p1KeyCount;
    private int p2KeyCount;
    //Range of elements in combos
    private int p1KeyRange;
    private int p2KeyRange;
    //Keyboard?
    public bool p1Keyboard;
    public bool p2Keyboard;

    public bool scaleDifficulty;
    ScoreManager score;

    //Collections of joystick inputs, setable to each player
    private List<KeyCode>[] joystickButtons;

    void Awake()
    {
        score = GetComponent<ScoreManager>();
        ListJoystickButtons();
        Init();
        StartCoroutine("UpdateDifficulty");
    }

    IEnumerator UpdateDifficulty()
    {
        if (scaleDifficulty)
        {
            ConfigureDifficulty();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("UpdateDifficulty");
    }

    void ListJoystickButtons()
    {
        joystickButtons = new List<KeyCode>[4];
        joystickButtons[0] = new List<KeyCode>();
        joystickButtons[0].Add(KeyCode.Joystick1Button0);
        joystickButtons[0].Add(KeyCode.Joystick1Button1);
        joystickButtons[0].Add(KeyCode.Joystick1Button2);
        joystickButtons[0].Add(KeyCode.Joystick1Button3);
        joystickButtons[0].Add(KeyCode.Joystick1Button4);
        joystickButtons[0].Add(KeyCode.Joystick1Button5);

        joystickButtons[1] = new List<KeyCode>();
        joystickButtons[1].Add(KeyCode.Joystick2Button0);
        joystickButtons[1].Add(KeyCode.Joystick2Button1);
        joystickButtons[1].Add(KeyCode.Joystick2Button2);
        joystickButtons[1].Add(KeyCode.Joystick2Button3);
        joystickButtons[1].Add(KeyCode.Joystick2Button4);
        joystickButtons[1].Add(KeyCode.Joystick2Button5);

        joystickButtons[2] = new List<KeyCode>();
        joystickButtons[2].Add(KeyCode.Joystick3Button0);
        joystickButtons[2].Add(KeyCode.Joystick3Button1);
        joystickButtons[2].Add(KeyCode.Joystick3Button2);
        joystickButtons[2].Add(KeyCode.Joystick3Button3);
        joystickButtons[2].Add(KeyCode.Joystick3Button4);
        joystickButtons[2].Add(KeyCode.Joystick3Button5);

        joystickButtons[3] = new List<KeyCode>();
        joystickButtons[3].Add(KeyCode.Joystick4Button0);
        joystickButtons[3].Add(KeyCode.Joystick4Button1);
        joystickButtons[3].Add(KeyCode.Joystick4Button2);
        joystickButtons[3].Add(KeyCode.Joystick4Button3);
        joystickButtons[3].Add(KeyCode.Joystick4Button4);
        joystickButtons[3].Add(KeyCode.Joystick4Button5);
    }

    public void Init()
    {
        //p1 Inputs
        P1Inputs = new List<KeyCode>();
        P1Inputs.Add(KeyCode.Z);
        P1Inputs.Add(KeyCode.S);
        P1Inputs.Add(KeyCode.A);
        P1Inputs.Add(KeyCode.W);
        P1Inputs.Add(KeyCode.Alpha2);
        P1Inputs.Add(KeyCode.Alpha3);
        //Joystick
        for(int i=0; i<p1Controller.Length; i++)
        {
            if(p1Controller[i] == true)
            {
                for (int j = 0; j < joystickButtons[i].Count; j++)
                {
                    P1Inputs.Add(joystickButtons[i][j]);
                }
            }
        }
        
        //P1Inputs.Add(KeyCode.Joystick1Button1);
        //P1Inputs.Add(KeyCode.Joystick1Button2);
        //P1Inputs.Add(KeyCode.Joystick1Button3);
        //P1Inputs.Add(KeyCode.Joystick1Button4);
        //P1Inputs.Add(KeyCode.Joystick1Button5);

        //p2 Inputs
        P2Inputs = new List<KeyCode>();
        P2Inputs.Add(KeyCode.M);
        P2Inputs.Add(KeyCode.K);
        P2Inputs.Add(KeyCode.J);
        P2Inputs.Add(KeyCode.I);
        P2Inputs.Add(KeyCode.Alpha8);
        P2Inputs.Add(KeyCode.Alpha9);
        //Joystick
        //P2Inputs.Add(KeyCode.Joystick2Button0);
        //P2Inputs.Add(KeyCode.Joystick2Button1);
        //P2Inputs.Add(KeyCode.Joystick2Button2);
        //P2Inputs.Add(KeyCode.Joystick2Button3);
        //P2Inputs.Add(KeyCode.Joystick2Button4);
        //P2Inputs.Add(KeyCode.Joystick2Button5);

        //Joystick
        for (int i = 0; i < p2Controller.Length; i++)
        {
            if (p2Controller[i] == true)
            {
                for (int j = 0; j < joystickButtons[i].Count; j++)
                {
                    P2Inputs.Add(joystickButtons[i][j]);
                }
            }
        }

        ConfigureDifficulty();
    }

    public List<KeyCode> AllButtons(int player)
    {
        if(player == 0)
        {
            return P1Inputs;
        }
        else
        {
            return P2Inputs;
        }
    }

    // Use this for initialization
    public List<KeyCode> Generate (int player)
    {
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
        float lowerLimit = -score.targetScore;
        float div = (score.targetScore * 2) * 0.2f;
        //and the current score
        float currentScore = score.currentScore;

        //compare the current score to divisions of 5 within the score range, shift difficulties accordingly
        if(currentScore < lowerLimit + div)
        {
            //Debug.Log("lowest");
            p1KeyCount = 4;
            p1KeyRange = 4;

            p2KeyCount = 8;
            p2KeyRange = 6;
        }
        else if(currentScore < lowerLimit + (div * 2))
        {
            //Debug.Log("low");
            p1KeyCount = 5;
            p1KeyRange = 4;

            p2KeyCount = 7;
            p2KeyRange = 4;
        }
        else if(currentScore < lowerLimit + (div * 3))
        {
            //Debug.Log("mid");
            p1KeyCount = 6;
            p1KeyRange = 4;

            p2KeyCount = 6;
            p2KeyRange = 4;
        }
        else if (currentScore < lowerLimit + (div * 4))
        {
            //Debug.Log("high");
            p1KeyCount = 7;
            p1KeyRange = 4;

            p2KeyCount = 5;
            p2KeyRange = 4;
        }
        else
        {
            //Debug.Log("highest");
            p1KeyCount = 8;
            p1KeyRange = 6;

            p2KeyCount = 4;
            p2KeyRange = 4;
        }
    }
}
