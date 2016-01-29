using UnityEngine;
using System.Collections;

public class PunManager : MonoBehaviour
{
    public string[] goodPuns;
    public string[] badPuns;

    public string GetPun(bool goodPun)
    {
        int randomPun = 0;

        if (goodPun)
        {
            if (goodPuns.Length == 0)
                return "lol no pun";
            else
            {
                randomPun = Random.Range(0, goodPuns.Length);
                return goodPuns[randomPun];
            }           
        }
        else
        {
            if (badPuns.Length == 0)
                return "lol no pun";
            else
            {
                randomPun = Random.Range(0, badPuns.Length);
                return badPuns[randomPun];
            }
        }
    }
}