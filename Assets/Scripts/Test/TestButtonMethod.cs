using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TestButtonMethod : MonoBehaviour, IPointerDownHandler
{
	public string steerObjectName = "Tester";
	/*
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	*/
	public virtual void OnPointerDown(PointerEventData ped)
	{		
		//GameObject.Find(steerObjectName).GetComponent<Dealer>().readerTest();
	}
}
