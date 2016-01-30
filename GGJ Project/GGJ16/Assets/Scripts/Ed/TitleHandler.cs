using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleHandler : MonoBehaviour
{
    public GameObject creditsPanel;
    public void ToggleCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
    public void StartGame()
    {
        //Load relevant level
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
