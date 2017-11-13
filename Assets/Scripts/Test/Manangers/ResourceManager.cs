using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	[SerializeField]	GameManager coreCtrl;
	//하위
	[SerializeField]	GraphicMananger graphicCtrl;
	[SerializeField]	SoundManager soundCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Awake()
	{
		
		
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

	//명령 하달 : 스테이지 시작
	public void stageStarting()
	{
		graphicCtrl.sendStageStart( );
		soundCtrl.musicOn( );
	}

	//미싱 노트 오브젝트 처리 명령 하달
	public void sendMissingNote(int lineNum)
	{
		graphicCtrl.sendMissingNote(lineNum);
	}
}

