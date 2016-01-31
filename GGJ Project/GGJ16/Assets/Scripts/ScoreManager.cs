using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public float targetScore;

    public int correctButtonScore;
    public int correctComboScore;

    public float currentScore;
   // public float[] playerScore = new float[2];

    private int[] playerStreak = new int[2];

    void Awake()
    {
        for(int x = 0; x < 2; ++x)
        {
            playerStreak[x] = 1;
            //playerScore[x] = 0;
            currentScore = 0;
        }
    }

    void Update()
    {
        if (currentScore > targetScore)
            GetComponent<WinState>().GameOver(0);
        if (currentScore < -targetScore)
            GetComponent<WinState>().GameOver(1);
    }

	[ContextMenu("Player 1 Score")]
    void Player1Score()
    {
		HitCorrectButton(0);
    }

    [ContextMenu("Player 2 Score")]
	void Player2Score()
    {
		HitCorrectButton(1);
    }

    public void HitCorrectButton(int player)
    {
        //playerScore[player] += correctButtonScore * playerStreak[player];
        if (player == 0)
            currentScore += correctButtonScore * playerStreak[0];
        else
            currentScore -= correctButtonScore * playerStreak[1];
    }

    public void CompleteCombo(int player, float time)
    {
        ++playerStreak[player];
        // playerScore[player] += (correctComboScore / time);
        if (player == 0)
            currentScore += (correctComboScore / time);
        else
            currentScore -= (correctComboScore / time);
    }

    public void BreakCombo(int player)
    {
        playerStreak[player] = 1;
    }

    public float GetScorePercentage()
    {
        return (currentScore + targetScore) / (targetScore * 2f);
        //return (playerScore[player] / targetScore);
    }
}
