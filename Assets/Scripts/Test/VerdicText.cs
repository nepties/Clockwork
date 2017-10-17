using UnityEngine;
using System.Collections;

public class VerdicText : MonoBehaviour
{
	float fadingDuration;
	

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
