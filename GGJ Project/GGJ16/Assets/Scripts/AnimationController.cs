using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public int currentAnim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentAnim = -1;
    }

    void Update()
    {
        anim.SetInteger("AnimState", currentAnim);
    }

    public void PlayRandomAnimation()
    {
        int newAnimation = Random.Range(1, 7);
        StartCoroutine("PlayAnimation", newAnimation);
    }
    public void PlayFailAnimation()
    {
        Debug.Log("Playing Fail");
        Camera.main.GetComponent<CameraShake>().MediumShake();
        StartCoroutine("PlayAnimation", 7);
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

        Debug.Log("Setting back to 0");
        currentAnim = -1;
    }

}
