using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public float targetScore;

    public int correctButtonScore;
    public int correctComboScore; 

    private float[] playerScore = new float[2];

    private int[] playerStreak = new int[2];

    void Awake()
    {
        for(int x = 0; x < 2; ++x)
        {
            playerStreak[x] = 1;
            playerScore[x] = 0;
        }
    }

    public void HitCorrectButton(int player)
    {
        playerScore[player] += correctButtonScore * playerStreak[player];
    }

    public void CompleteCombo(int player, float time)
    {
        ++playerStreak[player];
        playerScore[player] += (correctComboScore / time);
    }

    public void BreakCombo(int player)
    {
        playerStreak[player] = 1;
    }

    public float GetScorePercentage(int player)
    {
        return (playerStreak[player] / targetScore);
    }
}
