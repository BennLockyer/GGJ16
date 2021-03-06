﻿using UnityEngine;
using System.Collections;

public class FemaleParticles : MonoBehaviour
{
    public GameObject heartParticles;
    public GameObject dinnerParticles;

    public float particleTime;

    private ScoreManager scoreManager;
    private LadyAnimation ladyAnimation;

    public float timer;
    void Awake()
    {
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        ladyAnimation = transform.GetChild(0).GetComponent<LadyAnimation>();
        heartParticles.SetActive(false);
        dinnerParticles.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= particleTime)
        {
            timer -= particleTime;
            heartParticles.SetActive(false);
            dinnerParticles.SetActive(false);

            if (scoreManager.currentScore == 0) return;

            int randomInt = Random.Range(0, 2);
            float angle = 0;
            if (randomInt == 0)
            {
                if (scoreManager.currentScore > 0)
                    angle = -20f;
                else
                    angle = 20f;
                heartParticles.transform.localEulerAngles = new Vector3(0, angle, 0);
                ladyAnimation.PlaySendAnimation();
                heartParticles.SetActive(true);
            }
            else
            {
                if (scoreManager.currentScore < 0)
                    angle = -20f;
                else
                    angle = 20f;
                dinnerParticles.transform.localEulerAngles = new Vector3(0, angle, 0);
                ladyAnimation.PlaySendAnimation();
                dinnerParticles.SetActive(true);
            }
            
        }
    }
}
