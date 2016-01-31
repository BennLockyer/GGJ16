using UnityEngine;
using System.Collections;

public class WinState : MonoBehaviour
{
    public SpiderCombo spiderOne;
    public SpiderCombo spiderTwo;
    public GameObject UIObject;

    public Transform ladySpider;

    public Transform playerOne;
    public Transform playerTwo;

    public GameObject winParticles;

    private GameObject loser;

    private Vector3 target;
    private Vector3 ladyPos;

    private float distance;
    private float moveSpeed = 50f;
    private float startTime;
    private bool isMoving;

    public void GameOver(int winner)
    {
        StartCoroutine("EndGame", winner);
    }

    IEnumerator EndGame(int winner)
    {
        spiderOne.enabled = false;
        spiderTwo.enabled = false;
        UIObject.SetActive(false);

        if (winner == 0)
        {
            target = playerTwo.position;
            loser = playerTwo.gameObject;
        }
        else
        {
            target = playerOne.position;
            loser = playerOne.gameObject;
        }
        ladySpider.LookAt(target);

        yield return new WaitForSeconds(1.0f);

        ladyPos = ladySpider.position;
        startTime = Time.time;
        distance = Vector3.Distance(ladyPos, target);
        isMoving = true;
        ladySpider.transform.GetChild(0).GetComponent<LadyAnimation>().PlayAttackAnimation();

        yield return new WaitForSeconds(2.0f);

        if (winner == 0)
        {
            target = playerOne.position;
        }
        else
        {
            target = playerTwo.position;
        }

        ladySpider.LookAt(target);

        winParticles.transform.position = ladySpider.transform.position;
        float angle = 0;
        if (winner == 0)
            angle = 90f;
        else
            angle = -90f;
        winParticles.transform.eulerAngles = new Vector3(0, angle, 0);
        winParticles.SetActive(true);

        yield return new WaitForSeconds(4.0f);

        Application.LoadLevel(0);
    }

    void Update()
    {
        if(isMoving)
        {
            if(ladySpider.position != target)
            {
                float covered = (Time.time - startTime) * moveSpeed;
                float perc = covered / distance;
                ladySpider.position = Vector3.Lerp(ladyPos, target, perc);
               
            }
            else
            {
                if (loser != null) loser.SetActive(false);
                isMoving = false;
            }
        }
    }
}
