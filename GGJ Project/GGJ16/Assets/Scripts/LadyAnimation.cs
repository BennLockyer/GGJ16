using UnityEngine;
using System.Collections;

public class LadyAnimation : MonoBehaviour
{
    private Animator anim;
    public int currentAnim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentAnim = 0;
    }

    void Update()
    {
        anim.SetInteger("AnimState", currentAnim);
    }

    public void PlaySendAnimation()
    {
        StartCoroutine("PlayAnimation", 1);
    }

    public void PlayAttackAnimation()
    {
        StartCoroutine("PlayAnimation", 2);
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

        currentAnim = 0;
    }

}
