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

    private PunManager punManager;

    void Awake()
    {
        startPosition = transform.position;
        punManager = GameObject.FindWithTag("PunManager").GetComponent<PunManager>();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,50,50),""))
        {
            SetPun(new Vector3(10,10,0),Random.Range(0,2) == 1 ? true : false);
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

    public void SetPun(Vector3 targetPos, bool goodPun)
    {
        if(punManager == null)
            GetComponent<TextMesh>().text = "lol no pun";
        else
        {
            GetComponent<TextMesh>().text = punManager.GetPun(goodPun);
        }
        targetPosition = targetPos;
        startTime = Time.time;
        distance = Vector3.Distance(transform.position, targetPosition);
        isMoving = true;
    }
}
