using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	InputKeyManager inputCtrl;
	DataManager dataCtrl;
	ResourceManager resourceCtrl;
	byte gameState;

	//클라이언트 게임 진행 상태
	public enum clientState : byte
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
		gameState = (byte)clientState.enteringStage;  //최초 상태 : 스테이지 로딩
		forceloadingStage( );  //상태에 따른 명령 하달(For Test)
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

	//상태에 따른 명령 : 스테이지 로딩(선곡 후 행할 로직)
	void forceloadingStage( )
	{
		Debug.Log("Music selected, force stage Loading...");
		//곡 하나 읽어들이기
		StartCoroutine(loadForTest( ));
	}

	//상태 접수 : 파일 로드 끝
	public void receiveState_fileLoaded( )
	{
		//바로 명령 하달
		Debug.Log("file Data load complete!");
		forceUpdateDataFromFileData( );
	}

	//상태에 따른 명령 : 선곡 음악 데이터 업데이트(스테이지 로딩 2단계)
	void forceUpdateDataFromFileData( )
	{
		Debug.Log("Prepare Stage...(Phase 01)");
		//스테이지 준비!
		dataCtrl.prepareStage( );
	}

	IEnumerator loadForTest()
	{
		Debug.Log("waiting for fileReader Object making...");
		yield return new WaitForSeconds(1f);
		//곡 하나 읽어들이기
		dataCtrl.forceLoadOneFile( );
	}
}
