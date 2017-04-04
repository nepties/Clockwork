using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
	GameManager coreCtrl;
	GraphicMananger graphicCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
		graphicCtrl = GameObject.Find("GraphicManager").GetComponent<GraphicMananger>();
	}


	// Update is called once per frame
	void Update()
	{

	}

	public void rotateNeedleObject(float rotDegree)
	{
		
	}
}

