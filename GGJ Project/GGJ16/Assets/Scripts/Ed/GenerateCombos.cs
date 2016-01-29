using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void Awake()
    {
        p1KeyCount = 4;
        p2KeyCount = 4;
    }

	// Use this for initialization
	public List<KeyCode> Generate (int player)
    {
        if (player == 0)
        {
            //Player one combo generation
            P1Combo = new List<KeyCode>();
            for (int i = 0; i < p1KeyCount; i++)
            {
                P1Combo.Add(P1Inputs[Random.Range(0, p1KeyCount)]);
            }
            //Pass the combo to the player
            return P1Combo;
        }
        else
        {
            //Player one combo generation
            P2Combo = new List<KeyCode>();
            for (int i = 0; i < p2KeyCount; i++)
            {
                P2Combo.Add(P2Inputs[Random.Range(0, p2KeyCount)]);
            }
            //Pass the combo to the player
            return P2Combo;
        }
	}
}
