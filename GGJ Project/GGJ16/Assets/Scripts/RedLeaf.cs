using UnityEngine;
using System.Collections;

public class RedLeaf : MonoBehaviour
{
    public MeshRenderer[] leaf;
    public Color redColor;
    public float time;

    private Color[] startColor = new Color[2];
    private float[] timer = new float[2];

    void Awake()
    {
        startColor[0] = leaf[0].material.color;
        startColor[1] = leaf[1].material.color;
        timer[0] = time;
        timer[1] = time;
    }

    public void FlashLeaf(int player)
    {
        timer[player] = 0f;
    }
    
    void Update()
    {
        for(int x = 0; x < 2; ++x)
        {
            if(timer[x] < time)
            {
                float perc = timer[x] / time;
                leaf[x].material.color = Color.Lerp(redColor, startColor[x], perc);
                timer[x] += Time.deltaTime;

                if (timer[x] > time)
                    timer[x] = time;
            }
        }
    }
    
}
