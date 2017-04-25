using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	InputKeyManager inputCtrl;
	DataManager dataCtrl;
	ResourceManager resourceCtrl;
	byte clientState;

	//클라이언트 게임 진행 상태
	enum gameState : byte
	{
		firstEntry,  //최초 로딩
		InMainMenu,  //메인 메뉴
		enteringList,  //선곡 화면 로딩
		InList,  //선곡 화면
		enteringStage,  //스테이지 로딩
		InStage,  //스테이지 화면
		result  //결과 화면
	};

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//제어 개체 레퍼런스 받아오기
		inputCtrl = GameObject.Find("KeyInputMananger").GetComponent<InputKeyManager>();
		dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>();
		resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();

		//상태 설정 부
		clientState = (byte)gameState.enteringStage;  //최초 상태 : 스테이지 로딩
	}	

	// Update is called once per frame
	void Update ()
	{
		
	}
	 

	//바늘 회전 키입력 감지 & 명령 하달
	public void NeedleCtrlKeyInput(float rotDegree)
	{
		dataCtrl.rotateNeedleData(rotDegree);
		resourceCtrl.rotateNeedleObject(rotDegree);
	}

	//롱노트 활성화 키입력 감지 & 명령 하달
	public void longActiveKeyInput()
	{
		dataCtrl.LongNoteEngage();
	}

	//롱노트 '비'활성화 키입력 감지 & 명령 하달
	public void longDeactiveKeyInput()
	{
		dataCtrl.LongNoteRelease();
	}
}
