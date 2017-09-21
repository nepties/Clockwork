using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	GameManager coreCtrl;
	//하위
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

	
	//명령 하달 : 바늘 회전 
	public void rotateNeedleObject(float rotDegree)
	{
		graphicCtrl.rotateNeedleObject(rotDegree);
	}

	//명령 하달 : 극초기 상태 스테이지 준비
	public void forcePrepareStage()
	{
		graphicCtrl.prepareStage( );
	}

	public void stageStarting()
	{
		soundCtrl.musicOn( );
	}
}

