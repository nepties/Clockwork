using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
	//클래스 레퍼런스s
	GameManager coreCtrl;  //GM
	NoteReferee refereeCtrl;  //노트 판정확인 클래스
	fileReader fileDataCtrl;  //파일 정보 수입 클래스

	//노트 관련
	int needlePhase;  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
	bool isLongactivated;  // 롱노트 활성화 여부
	
	//배속 관련
	float curBpm;  //현재 재생 곡 BPM
	[SerializeField]
	[Range((0), (10))]
	float speedConstant;  //배속 상수
	float speedMultiplier;  //배속 승수
	float finalSpeed;  //최종 계산 배속
	float noteReadDelay;//bpm에 따른 읽기 지연 시간(ms)

	//수입 파일 데이터 저장 공간
	List<MusicMetaData> metaDataStorage;  //읽은 곡들 메타 데이터
	List<MusicNoteData> noteDataStorage;  //선택 곡의 노트 데이터

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
		refereeCtrl = GameObject.Find("NoteReferee").GetComponent<NoteReferee>();
		fileDataCtrl = GameObject.Find("fileReader").GetComponent<fileReader>();

		//설정 초기화 부
		//파일 데이터 저장소 연결
		metaDataStorage = fileDataCtrl.getMetaStorageLink( );
		noteDataStorage = fileDataCtrl.getNoteStorageLink( );

		updateReadingDelay();  //노트 데이터 읽기 지연 시간 계산
	}
	

	// Update is called once per frame
	void Update()
	{
	
	}


	//바늘 회전 메소드
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

	//노트 읽기 지연시간 계산 메소드
	public void updateReadingDelay()
	{
		noteReadDelay = 3750f / curBpm;
	}

	//선곡된 곡 메타데이터 정보 받아오기
	void applySelectedMusicMeta( )
	{
		
	}
}
