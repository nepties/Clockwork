using UnityEngine;
using System.Collections.Generic;

public class VerdicText : MonoBehaviour
{
	float fadingDuration;
	
    [SerializeField] List<GameObject> cupList = new List<GameObject>();

	// Use this for initialization
	void Awake ()
	{
		fadingDuration = 1.5f;		
	}

	public void writeText(int type)
	{
		
	}

	public void fadeOut()
	{
		Mathf.MoveTowards(1, 0, Time.deltaTime * (1 / fadingDuration)); 
	}
}
