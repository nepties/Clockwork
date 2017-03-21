using UnityEngine;
using System.Collections;

public class InputKeyManager : MonoBehaviour
{
	public string steerObjectName = "clockNeedle";
	GameObject steerObject;	

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		steerObject = GameObject.Find(steerObjectName);
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown("space"))
		if (Input.GetKeyDown(KeyCode.F))
			steerObject.GetComponent<Rotator>().rotateNeedle(-1);

		if (Input.GetKeyDown(KeyCode.D))
			steerObject.GetComponent<Rotator>().rotateNeedle(-3);

		if (Input.GetKeyDown(KeyCode.J))
			steerObject.GetComponent<Rotator>().rotateNeedle(1);

		if (Input.GetKeyDown(KeyCode.K))
			steerObject.GetComponent<Rotator>().rotateNeedle(3);
	}
}