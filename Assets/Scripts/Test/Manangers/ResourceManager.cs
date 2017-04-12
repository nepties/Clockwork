using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
	GameManager coreCtrl;
	GraphicMananger graphicCtrl;
	SoundManager soundCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
		graphicCtrl = GameObject.Find("GraphicManager").GetComponent<GraphicMananger>();
		soundCtrl = GameObject.Find("SoundMaster").GetComponent<SoundManager>();
	}


	// Update is called once per frame
	void Update()
	{

	}

	
	//바늘 회전 명령 하달
	public void rotateNeedleObject(float rotDegree)
	{
		graphicCtrl.rotateNeedleObject(rotDegree);
	}
}

