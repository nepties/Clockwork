using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	GameManager coreCtrl;  //GM
	//하위
	NoteReferee refereeCtrl;  //노트 판정확인 클래스
	fileReader fileDataCtrl;  //파일 정보 수입 클래스

	//노트 관련
	public int needlePhase { get; set; }  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
	public bool isLongactivated { get; set; }  // 롱노트 활성화 여부
	public int curReadingUnit  { get; set; }  //현재 읽기 위치 (유닛 단위)
	public int initialLoadaAmount  { get; set; }  //초기 로딩 노트 수
	
	//배속 관련
	float curBpm;  //현재 재생 곡 BPM
	[SerializeField]	[Range((0), (10))]	float speedConstant;  //배속 상수
	float speedMultiplier;  //배속 승수
	float finalSpeed;  //최종 계산 배속
	float noteReadDelay;  //bpm에 따른 읽기 지연 시간(ms)
	float noteReadDelayForSecond;  //bpm에 따른 읽기 지연 시간(sec)


	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
		refereeCtrl = GameObject.Find("NoteReferee").GetComponent<NoteReferee>();
		fileDataCtrl = GameObject.Find("fileReader").GetComponent<fileReader>();

		//초기화 부
		initialLoadaAmount = 32;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	//바늘 회전 메소드(숏노트 계)
	public void rotateNeedleData(float rotateDegree)  // rotateDegree : 1, -1, 3, -3 칸 회전 값
	{
		needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //바늘 위치 단계 계산
	}
	
	//롱노트 입력 활성화 정보 수정
	public void LongNoteEngage()
	{
		isLongactivated = true;
		Debug.Log("force Long Active");
	}

	//롱노트 입력 활성화 정보 수정
	public void LongNoteRelease()
	{
		isLongactivated = false;
		Debug.Log("force Long DeActive");
	}

	//곡 하나 읽기 명령 하달(For Test)
	public void forceLoadOneFile()
	{
		fileDataCtrl.readOneFullFile( );
	}

	//상태 보고 to GM : 선곡 음악 파일 로드 완료
	public void reportLoadfinished( )
	{
		coreCtrl.receiveState_fileLoaded( );
	}

	//스테이지 로딩 상태 2 : 변수 초기화
	public void prepareStage( )
	{
		//현재 BPM 정보 최초 초기화
		curBpm = fileDataCtrl.metaDataStorage[0].bpm;
		noteReadDelay = 3750f / curBpm; //읽기 지연 시간 초기화
		noteReadDelayForSecond = noteReadDelay / 1000;
		Debug.Log("first set BPM : " + curBpm);
		Debug.Log("first set readDelay : " + noteReadDelay);
		coreCtrl.forcePrepareInitialStage( );
	}

	//보면 리더(For Test)
	public IEnumerator noteReaderMachine()
	{
		while(coreCtrl.gameState == 5)
		{


			yield return new WaitForSeconds(noteReadDelayForSecond);  //노트 읽기 딜레이
		}	
	}
}
