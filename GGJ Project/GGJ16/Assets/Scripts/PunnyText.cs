using UnityEngine;
using System.Collections;

public class PunnyText : MonoBehaviour
{
    public float movementSpeed;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    
    private float startTime;
    private float distance;

    private bool isMoving;

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,50,50),""))
        {
            SetPun("lol",new Vector3(10, 10, 0));
        }
    }
    
    void Update()
    {
        if(isMoving)
        {
            if (transform.position == targetPosition)
                Destroy(gameObject);
            else
            {
                float covered = (Time.time - startTime) * movementSpeed;
                float perc = covered / distance;
                transform.position = Vector3.Lerp(startPosition, targetPosition, perc);
            }
        }
    }

    public void SetPun(string punText, Vector3 targetPos)
    {
        GetComponent<TextMesh>().text = punText;
        targetPosition = targetPos;
        startTime = Time.time;
        distance = Vector3.Distance(transform.position, targetPosition);
        isMoving = true;
    }
}
