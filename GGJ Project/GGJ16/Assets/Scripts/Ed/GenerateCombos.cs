using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GenerateCombos : MonoBehaviour
{
    //VARIABLES
    //Combos
    private List<KeyCode> P1Combo;
    private List<KeyCode> P2Combo;
    //Input list
    public List<KeyCode> P1Inputs;
    public List<KeyCode> P2Inputs;
    //Number of elements in combos
    private int p1KeyCount;
    private int p2KeyCount;
    //Difficulty level for players
    private int p1Difficulty;
    private int p2Difficulty;
    //Keyboard?
    public bool p1Keyboard;
    public bool p2Keyboard;

    void Awake()
    {
        p1KeyCount = 4;
        p2KeyCount = 4;
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
                P1Combo.Add(P1Inputs[UnityEngine.Random.Range(shift, p1KeyCount + shift)]);
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
                P2Combo.Add(P2Inputs[UnityEngine.Random.Range(shift, p2KeyCount + shift)]);
            }
            //Pass the combo to the player
            return P2Combo;
        }
	}
}
