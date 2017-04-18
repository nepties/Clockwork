using UnityEngine;
using System.Collections;

public class NoteReferee : MonoBehaviour
{
	DataManager DataCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		DataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
