using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderCombo : MonoBehaviour
{
    public GenerateCombos gen;
    public int player;
    public List<KeyCode> combo;
    private float timer;
    private int curStep;

    public int health;
    private KeyCode keyPress;

	// Use this for initialization
	void Start ()
    {
        NewCombo();
	}

    void OnGUI()
    {
        //Has to be in OnGUI for some reason...
        keyPress = Event.current.keyCode;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.smoothDeltaTime;
        //Check there's a keypress
        if (keyPress != KeyCode.None)
        {
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
                        curStep++;
                        health++;
                        if(curStep == combo.Count)
                        {
                            NewCombo();
                        }
                    }
                    else
                    {
                        health--;
                    }
                }
            }
        }
	}

    //get us a new combo, pass timer to help calculate score
    void NewCombo()
    {
        combo = gen.Generate(player);
        curStep = 0;
        timer = 0;
        //Debug.Log("Return");
    }
}
