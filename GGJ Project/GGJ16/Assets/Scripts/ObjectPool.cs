using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Basic Object Pool Class
// One instance of this object will manage one type of object
// Will only work with GameObjects
// An object will be available or ready, when GameObject is not active
// Object classed as inuse when the object is active

public class ObjectPool : MonoBehaviour 
{
	[SerializeField]
	private GameObject targetObject = null;
	private List<GameObject> ObjectList;

	void Awake() 
	{
		ObjectList = new List<GameObject>();
	}

	void Start()
	{
		for(int i = 0; i < 5; i++)
			CreateNewObject();
	}

	void Update()
	{
		for(int i = 0; i < ObjectList.Count; i++)
		{
			GameObject iObj = ObjectList[i];
			if(iObj.activeInHierarchy == false && iObj.transform.parent != transform)
				iObj.transform.parent = transform;
		}
	}

	// Get a single available object
	public GameObject GetAvailableObject()
	{
		GameObject newObj = null;

		for(int i = 0; i < ObjectList.Count; i++)
		{
			GameObject iObj = ObjectList[i];
			if(iObj.activeInHierarchy == false)
			{
				newObj = iObj;
				break;
			}
		}

		// If non-active objects found
		if(newObj == null) 
		{
			newObj = CreateNewObject();
		}

		return newObj;
	}

	GameObject CreateNewObject()
	{
		GameObject obj = (GameObject)GameObject.Instantiate(targetObject, Vector3.zero, Quaternion.identity);
		obj.transform.parent = transform;
		obj.SetActive(false);
		ObjectList.Add(obj);

		return obj;
	}
}
