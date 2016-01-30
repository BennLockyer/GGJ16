using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    public GenerateCombos gen;
    public SpiderCombo p1;
    public SpiderCombo p2;

	// Use this for initialization
	void Start ()
    {
        //show UI elements
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Temp input system until UI is in
	    if(Input.GetKeyDown(KeyCode.A))
        {
            TogglePlayerKeyboard(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TogglePlayerKeyboard(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TogglePlayerAi(0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TogglePlayerAi(1);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Begin();
        }
    }

    void TogglePlayerKeyboard(int player)
    {
        if(player == 0)
        {
            gen.p1Keyboard = !gen.p1Keyboard;
        }
        else
        {
            gen.p2Keyboard = !gen.p2Keyboard;
        }
    }
    
    void TogglePlayerAi(int player)
    {
        if (player == 0)
        {
            p1.isAi = !p1.isAi;
        }
        else
        {
            p2.isAi = !p2.isAi;
        }
    }

    void Begin()
    {
        gen.Init();
        p1.enabled = true;
        p2.enabled = true;
    }
}
