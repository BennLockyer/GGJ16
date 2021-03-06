using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Intended to display Key Combo and Player Score

public class UIPlayerView : MonoBehaviour 
{
	[SerializeField]
	private int player;
    
	private SpiderCombo playerCombo;
	private GameObject keyComboContainer;
	private ObjectPool singleComboPool;
	private Keymap keyMap;

	void Awake() 
	{
		GameObject comboObjPool = GameObject.Find("/_UIStuff/SingleComboPool");
		if(comboObjPool != null)
			singleComboPool = comboObjPool.GetComponent<ObjectPool>();
		else
			Debug.LogError("Cannot find Single Combo Object Pool");

		keyComboContainer = transform.Find("ComboPanel").gameObject;
		if(keyComboContainer == null)
			Debug.LogError("Cannot find Score Bar Object");

		keyMap = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Keymap>();

        if (player == 0)
            playerCombo = GameObject.FindWithTag("Player1").GetComponent<SpiderCombo>();
        else
            playerCombo = GameObject.FindWithTag("Player2").GetComponent<SpiderCombo>();
    }

	void Update()
	{
        //DisplayCombo();
        Transform tCombo = keyComboContainer.transform;
        for (int i = 0; i < playerCombo.curStep; i++)
        {
            Transform obj = tCombo.GetChild(i);
            obj.transform.GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(true);
        }
    }

	public void DisplayCombo(List<KeyCode> keys)
	{
        //KeyCode[] keyCombo = keys.ToArray();
        List<KeyCode> keyCombo = keys;
        if (keyComboContainer == null) keyComboContainer = transform.Find("ComboPanel").gameObject;
        Transform tCombo = keyComboContainer.transform;

		// Remove all single key combo
		for(int i = 0; i < tCombo.childCount; i++) 
		{
			GameObject obj = tCombo.GetChild(i).gameObject;
			// This is so fucking retarded - GetComponentInChildren get component from the parent as well
			obj.transform.GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(false);
            obj.SetActive(false);
		}

        tCombo.DetachChildren();

        // Populate Key Combo Bar
        for (int i = 0; i < keyCombo.Count; i++) 
		{
			GameObject obj = singleComboPool.GetAvailableObject();
			obj.transform.SetParent(tCombo);
			obj.SetActive(true);
            Debug.Log(playerCombo.player.ToString() + " " + "UI OUTPUT" + i.ToString() + ": " + keyCombo[i].ToString());
			if(keyMap.HaveKey(keyCombo[i]))
			{
                obj.GetComponent<Image>().sprite = null;
                obj.GetComponent<Image>().sprite = keyMap.GetSprite(keyCombo[i]);
				obj.GetComponentInChildren<Text>().text = string.Empty;
			}
			else
			{
				obj.GetComponent<Image>().sprite = null;
				obj.GetComponentInChildren<Text>().text = keyCombo[i].ToString();
			}
		}

		/*for(int i = 0; i < playerCombo.curStep; i++) 
		{
			Transform obj = tCombo.GetChild(i);
			obj.transform.GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(true);
		}*/
	}
}
