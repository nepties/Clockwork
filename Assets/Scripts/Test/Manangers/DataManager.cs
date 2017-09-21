using UnityEngine;
using System.Collections.Generic;
using ReferenceSetting;
using MusicScrolls;

public class DataManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//최상위 (임시)
	StageTrigger triggerCtrl;
	//상위
	GameManager coreCtrl;  //GM
	//하위
	NoteReferee refereeCtrl;  //노트 판정확인 클래스
	fileReader fileDataCtrl;  //파일 정보 수입 클래스

	//노트 관련
	public int needlePhase { get; set; }  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
	public bool isLongactivated { get; set; }  // 롱노트 활성화 여부
	public int curReadingUnit  { get; set; }  //현재 읽기 위치 (유닛 단위)
	public int frontReadingUnit  { get; set; }  //선행 읽기 위치 (유닛 단위)
	public int initialLoadaAmount  { get; set; }  //초기 로딩 노트 수 : 프론트와 커런트 사이 유닛 값
	
	//배속 관련
	float curBpm;  //현재 재생 곡 BPM
	[SerializeField]	[Range((0), (10))]	float speedConstant;  //배속 상수
	float speedMultiplier;  //배속 승수
	float railSpeed;  //레일 스피드 : 최종 노트 속도
	float noteReadDelay;  //bpm에 따른 읽기 지연 시간(단위 : ms)
	float noteReadDelayForSecond;  //bpm에 따른 읽기 지연 시간(단위 : sec)	

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기		
		coreCtrl = AddressBook.coreCtrl;
		refereeCtrl = AddressBook.refereeCtrl;
		fileDataCtrl = AddressBook.fileDataCtrl;
		triggerCtrl = GameObject.Find("StageTrigger(Temp)").GetComponent<StageTrigger>( );  //임시

		//초기화 부
		curReadingUnit = 0;
		initialLoadaAmount = 20;  //초기 스테이지 배치 유닛 수
		frontReadingUnit = initialLoadaAmount;
		needlePhase = 0;			
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	//숏노트 처리 관련 메소드
	public void rotateNeedleData(float rotateDegree)  // rotateDegree : 1, -1, 3, -3 칸 회전 값(음수값 왼쪽)
	{
		needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //바늘 위치 단계 계산

		//노트 판정 실행
		//refereeCtrl.judgeShortNote()
	}
	
	//롱노트 입력 활성화
	public void LongNoteEngage( )
	{
		isLongactivated = true;
		Debug.Log("force Long Active");
	}

	//롱노트 입력 비활성화
	public void LongNoteRelease( )
	{
		isLongactivated = false;
		Debug.Log("force Long DeActive");
	}

	//곡 하나 읽기 명령 하달(For Test)
	public void forceLoadOneFile( )
	{
		fileDataCtrl.readOneFullFile( );
	}

	//특정 곡 리딩 완료
	public void reportReadfinished( )
	{
		//임시 트리거로 결과 보고
		triggerCtrl.FinalConfirmfileImportFinished( );  
	}

	//스테이지 로딩 상태 2 : 변수 초기화 & 노트데이터 재가공
	public void prepareStage( )
	{
		//현재 BPM 정보 최초 초기화
		curBpm = fileDataCtrl.metaDataStorage[0].bpm;
		noteReadDelay = 3750f / curBpm; //읽기 지연 시간 초기화
		noteReadDelayForSecond = noteReadDelay / 1000;
		Debug.Log("first set BPM : " + curBpm);
		Debug.Log("first set readDela(ms) : " + noteReadDelay);

		//재가공 : 노트 판정을 위한 데이터 큐 제작
		fileDataCtrl.extractJudgeScroll( );
	}

	//재가공 데이터 노트판정 객체에게 넘기기 & 스테이지 준비
	public void sendRefineData(Queue<NoteJudgeCard> [] RefineQueue)
	{
		refereeCtrl.receiveRefineData(RefineQueue);
		coreCtrl.dataAllLoaded( );  //GM 보고		
	}

	//스테이지 온
	public void stageStarting()
	{
		refereeCtrl.receiveStarting( );
	}
}


//노트, 메타데이터 정의 
namespace MusicScrolls
{
	//큐에 넣어질 노트 배치 요소
	public struct NoteJudgeCard
	{
		public int noteType { get; private set; }  //노트 타입
		public float time { get; private set; }  // 해당 NoteUnit의 재생 시간
		public int unitNum { get; private set; } //유닛 일련번호
	
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		public NoteJudgeCard(int noteType, float time, int unitNum)
		{
			this.noteType = noteType;
			this.time = time;
			this.unitNum = unitNum;
		}

		public void printContent()
		{
			Debug.Log(noteType + "::" + time + "__(" + unitNum + ")");
		}
	}

	//메타 데이터 클래스
	public class MusicMetaData
	{
		//채보 메타 데이터
		public string title { get; private set; }  //음악제목
		public string jacket { get; private set; }  //음악이미지 파일명(경로)
		public string difficulty { get; private set; }  //보면 난이도
		public string music { get; private set; }  //음악 파일명(경로)
		public int length { get; set; }  //음악 길이(second)
		public float bpm { get; set; }  //Beat Per Minute
		public int unit { get; set; }  //보면 유닛 수

		//노트 배치 데이터
		//MusicNoteData noteStruct;  //노트 데이터 관리 클래스 레퍼런스
	
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	
		//메타 데이터 추가 생성자
		public MusicMetaData(List<string> metaList)
		{
			title = metaList[0];
			jacket = metaList[1];
			difficulty = metaList[2];
			music = metaList[3];
			length = int.Parse(metaList[4]);
			bpm = float.Parse(metaList[5]);
			unit = int.Parse(metaList[6]);
		}

		//메타 데이터 리스트 출력 (한 줄로 Test)
		public void printMetaData()
		{
			Debug.Log(title + " || " + jacket + " || " + difficulty + " || " + music + " || " + length + " || " + bpm + " || " + unit);
		}
	}

	//노트 데이터 저장 구조체
	public struct MusicNoteData
	{
		int[] noteData;  // 노트 배치 정보. 크기는 13
		float time;  // 해당 NoteUnit의 재생 시간
		int unitTiming; //유닛 일련번호
		bool hasNoteData;  //해당 유닛에 노트 존재 여부

		//000 | 000 | 000 | 000 | 0  ---+ 처리 시점

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//구조체 생성자 & 입력
		public MusicNoteData(int[] unitNoteData, float unitTime, int treatUnit, bool hasNoteData)
		{
			noteData = unitNoteData;
			time = unitTime;
			unitTiming = treatUnit;
			this.hasNoteData = hasNoteData;
		}

		//현재시점 노트 정보 전달 메소드
		public int[] getLocatedArray()
		{
			return noteData;
		}

		//(Test) 해당 시점 노트 정보 전체 출력
		public void printNoteArray()
		{
			foreach(int i in noteData)
			{
				Debug.Log(i + " : " + unitTiming);
			}
		}

		//Get : 노트 여부
		public bool noteExistCheck()
		{
			return hasNoteData;
		}

		//Get : 노트가 위치하는 유닛번호
		public int getLineUnit()
		{
			return unitTiming;
		}

		//Get : 해당 유닛의 재생 시점(ms)
		public float getLineTiming()
		{
			return time;
		}
	}
}
