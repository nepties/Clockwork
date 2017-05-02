using UnityEngine;
using System.Collections;

public class GameObjectsManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	GraphicMananger graphicCtrl;
	//하위
	ClockNeedle NeedleCtrl;
	NoteDealer noteObjectPoolCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		graphicCtrl = GameObject.Find("GraphicManager").GetComponent<GraphicMananger>();
		NeedleCtrl = GameObject.Find("clockNeedle").GetComponent<ClockNeedle>();
		noteObjectPoolCtrl = GameObject.Find("NoteDealer").GetComponent<NoteDealer>();
	}


	// Update is called once per frame
	void Update()
	{

	}


	//명령 하달 : 바늘 회전
	public void rotateNeedleObject(float rotDegree)
	{
		NeedleCtrl.rotateNeedle(rotDegree);
	}

	//명령 하달 : 초기 스테이지 준비!
	public void prepareStage()
	{

	}
}