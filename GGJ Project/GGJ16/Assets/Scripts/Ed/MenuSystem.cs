using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public GenerateCombos gen;
    public SpiderCombo p1;
    public SpiderCombo p2;
    public GameObject menuUi;

	// Use this for initialization
	void Start ()
    {
        //show UI elements
	}
	
	// Update is called once per frame
	void Update ()
    {
    	// Check if escape is pressed to toggle pause menu
    	if(Input.GetKeyDown(KeyCode.Escape))
    	{
			menuUi.SetActive(!menuUi.activeInHierarchy);
    	}
    }

    public void TogglePlayerKeyboard(int player)
    {
        if(player == 0)
        {
            gen.p1Keyboard = !gen.p1Keyboard;
            Debug.Log(gen.p1Keyboard.ToString());
        }
        else
        {
            gen.p2Keyboard = !gen.p2Keyboard;
            Debug.Log(gen.p2Keyboard.ToString());
        }
    }
    
    public void TogglePlayerAi(int player)
    {
        if (player == 0)
        {
            p1.isAi = !p1.isAi;
            Debug.Log(p1.isAi.ToString());
        }
        else
        {
            p2.isAi = !p2.isAi;
            Debug.Log(p2.isAi.ToString());
        }
    }

    public void Begin()
    {
        p1.enabled = true;
        p2.enabled = true;
        Destroy(menuUi);
    }
}
