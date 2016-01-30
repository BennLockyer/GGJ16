using UnityEngine;
using System.Collections;

public class StarPulse : MonoBehaviour
{
    public float maxAlpha;
    public float bpm;

    private float currentAlpha;
    private float frequency;
    private float timer;

    private Color startColor;

    private MeshRenderer mesh;

    void Awake()
    {
        frequency = 60f / bpm;
        mesh = GetComponent<MeshRenderer>();
        startColor = mesh.material.color;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            timer -= frequency;
            currentAlpha = maxAlpha;
        }

        if(currentAlpha > 0)
        {
            currentAlpha -= 0.01f;
            if (currentAlpha < 0)
                currentAlpha = 0;
            mesh.material.color = new Color(startColor.r, startColor.g, startColor.b, currentAlpha);
        }
    }
}
