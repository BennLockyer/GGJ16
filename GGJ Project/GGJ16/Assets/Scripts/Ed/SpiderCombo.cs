﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpiderCombo : MonoBehaviour
{
    //VARIABLES
    public bool isAi = false;
    public GenerateCombos gen;
    public ScoreManager score;
    public int player;
    public List<KeyCode> combo;
    private float animationDelay = 1.0f;
    private float timer;
    [HideInInspector]
    public int curStep;

    private bool acceptInput = true;

    private KeyCode keyPress;
    [HideInInspector]
    public bool isKeyboard;

    //AI variables
    [Range(0,100)]
    public int successChance;
    [Range(0,3)]
    public float baseStepTime;
    [Range(0,3)]
    public float stepTimeVariance;
    private float stepWait;
    private float AiStepTimer;

    public UIPlayerView myUI;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("NewCombo",false);
        SetAi();
	}

    void OnGUI()
    {
        //Has to be in OnGUI for some reason...
        if (isKeyboard && Event.current.isKey)
        {
            keyPress = Event.current.keyCode;
        }
    }

    //Workaround for broken keycode event
    void ChooseKey()
    {
        if (!isKeyboard)
        {
            if (player == 0)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    keyPress = KeyCode.Joystick1Button0;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    keyPress = KeyCode.Joystick1Button1;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    keyPress = KeyCode.Joystick1Button2;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    keyPress = KeyCode.Joystick1Button3;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button4))
                {
                    keyPress = KeyCode.Joystick1Button4;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button5))
                {
                    keyPress = KeyCode.Joystick1Button5;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                {
                    keyPress = KeyCode.Joystick2Button0;
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                {
                    keyPress = KeyCode.Joystick2Button1;
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                {
                    keyPress = KeyCode.Joystick2Button2;
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                {
                    keyPress = KeyCode.Joystick2Button3;
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button4))
                {
                    keyPress = KeyCode.Joystick2Button4;
                }
                if (Input.GetKeyDown(KeyCode.Joystick2Button5))
                {
                    keyPress = KeyCode.Joystick2Button5;
                }
            }
        }

        CheckInput();
    }

    //Compare the keycode to the combo
    void CheckInput()
    {
        //Check there's a keypress
        if (keyPress != KeyCode.None)
        {
            Debug.Log(keyPress.ToString());
            Debug.Log(combo[curStep]);
            //make sure it's one of our keys
            bool hasKey = player == 0 ? gen.P1Inputs.Contains(keyPress) : gen.P2Inputs.Contains(keyPress);
            if (hasKey)
            {
                //step through the combo
                if (curStep < combo.Count)
                {
                    //Debug.Log(timer);
                    if (combo[curStep] == keyPress)
                    {
                        //Successful step
                        curStep++;
                        score.HitCorrectButton(player);
                        //Successful combo
                        if (curStep == combo.Count)
                        {
                            score.CompleteCombo(player, timer);
                            StartCoroutine("NewCombo",true);
                        }
                        keyPress = KeyCode.None;
                    }
                    else
                    {
                        //Missed step
                        score.BreakCombo(player);
                        StartCoroutine("NewCombo",false);
                        keyPress = KeyCode.None;
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.smoothDeltaTime;

        if (!acceptInput) return;

        if (isAi)
        {
            AiGameplay();
        }
        else
        {
            ChooseKey();
        }
	}

    private void AiGameplay()
    {
        AiStepTimer += Time.smoothDeltaTime;
        if(AiStepTimer >= stepWait)
        {
            if(UnityEngine.Random.Range(0,100) <= successChance)
            {
                //Successful step
                curStep++;
                score.HitCorrectButton(player);
                //Successful combo
                if (curStep == combo.Count)
                {
                    score.CompleteCombo(player, timer);
                    StartCoroutine("NewCombo",true);
                }
                keyPress = KeyCode.None;
            }
            else
            {
                //Missed step
                score.BreakCombo(player);
                StartCoroutine("NewCombo",false);
                keyPress = KeyCode.None;
            }
            SetAi();
            AiStepTimer = 0;
        }
    }

    void SetAi()
    {
        stepWait = UnityEngine.Random.Range(-stepTimeVariance, stepTimeVariance) + baseStepTime;
        stepWait = Mathf.Abs(stepWait);
    }

    //get us a new combo, pass timer to help calculate score
    IEnumerator NewCombo(bool needsDelay)
    {
        if (needsDelay)
        {
            acceptInput = false;
            yield return new WaitForSeconds(animationDelay);
        }
        combo = gen.Generate(player);
        curStep = 0;
        timer = 0;
        acceptInput = true;
        //Debug.Log("Return");

        //set if we're using keyboard or not depending on our player
        isKeyboard = player == 0 ? gen.p1Keyboard : gen.p2Keyboard;
        myUI.DisplayCombo(combo);
    }
}
