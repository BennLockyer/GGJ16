using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleHandler : MonoBehaviour
{
    //Animation
    public Animator anim;
    public int currentAnim;

    void Awake()
    {
        currentAnim = -1;
        StartCoroutine("PlayAnimation", currentAnim);
    }

    void Update()
    {
        anim.SetInteger("AnimState", currentAnim);
    }

    void PlayRandomAnimation()
    {
        int newAnimation = Random.Range(1, 7);
        StartCoroutine("PlayAnimation", newAnimation);
    }

    IEnumerator PlayAnimation(int animNumber)
    {
        currentAnim = animNumber;
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        while (info.IsName("Idle"))
        {
            yield return new WaitForEndOfFrame();
            info = anim.GetCurrentAnimatorStateInfo(0);
        }

        currentAnim = -1;
        PlayRandomAnimation();
    }

    public GameObject creditsPanel;
    public void ToggleCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
    public void StartGame()
    {
        //Load relevant level
        Application.LoadLevel(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
