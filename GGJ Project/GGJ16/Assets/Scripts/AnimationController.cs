﻿using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public int currentAnim;
    public int player;

    private RedLeaf redLeaf;

    void Awake()
    {
        anim = GetComponent<Animator>();
        redLeaf = GameObject.FindWithTag("GameManager").GetComponent<RedLeaf>();
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
        redLeaf.FlashLeaf(player);
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

        currentAnim = -1;
    }

}
