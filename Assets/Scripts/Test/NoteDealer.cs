using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MusicScrolls;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class NoteDealer : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	GameObjectsManager gameObjectCtrl;

	[SerializeField]  GameObject noteObject;  //숏 노트 오브젝트	
	int poolSize;  //오브젝트 풀 최대 수용량

	//오브젝트 풀 레퍼런스
	Queue<GameObject> [] poolQueue;  //비활성 오브젝트 대기큐
	Queue<GameObject> [] activePoolQueue;  //활성 오브젝트 관리큐

	//기타
	float finalSpeed;  //임의 최종 속도
	Queue<NoteJudgeCard> [] judgeScroll;  //복사본(임시)
	Stopwatch stopwatch = NoteReferee.stopwatch;  //노트 딜러 클래스의 스톱워치 받기
	float preLoadingTime;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Awake ()
	{
		//제어 개체 레퍼런스 받아오기
		gameObjectCtrl = GameObject.Find("GameObjects").GetComponent<GameObjectsManager>();
		
		//초기, 임의값 초기화 부
		poolSize = 20;  //생성량 초기설정값
		finalSpeed = 600f;  //임의 지정 최종 속도
		preLoadingTime = 1f;  //1초 프리로딩

		//비활성 오브젝트 대기큐 배열 생성 부
		poolQueue = new Queue<GameObject>[12]; 
		for(int i = 0; i < 12; i++)  //12개 대기열
		{
			poolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
		}

		//활성 오브젝트 관리큐 배열 생성 부
		activePoolQueue = new Queue<GameObject>[12];
		for(int i = 0; i < 12; i++)  //12개 대기열
		{
			activePoolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
		}
				
		//오브젝트 생성 부
		createNoteObject();
		//로드 완료		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//숏노트 프리로딩
		for(int i = 0; i < 12; i++)
		{
			Queue<NoteJudgeCard> judgeLine = judgeScroll[i];

			//프리로드 시점에 걸친 노트 발견
			if(judgeLine.Peek().time <= stopwatch.ElapsedMilliseconds + preLoadingTime)
			{				
				forceDealNotes(judgeLine.Dequeue( ), i);  //큐에서 제외
				Debug.Log("Pop ShortNote! __ PreLoading");
			}
		}
	}

	//풀링할 오브젝트 생성 메소드
	void createNoteObject()
	{
		//설정 수 만큼 생성 부
		for(int i = 0; i < 12; i++)
		{
			for(int j = 0; j < poolSize; j++)
			{
				GameObject creation = (GameObject)Instantiate(noteObject, this.transform.position, Quaternion.identity);  //오브젝트 생성
				creation.transform.Rotate(i * -30f * Vector3.forward);  //알맞게 회전
				creation.SetActive(false);  //비활성화				
				//creation.GetComponent<NoteObjectMethod>( ).setQueueNumber(i);  //출신 대기큐 번호 부여
				poolQueue[i].Enqueue(creation);  //오브젝트를 대기큐 입력
			}
		}
	}

	//스테이지 최초 로드 직후 노트 배치
	void dealInitialNote()
	{

	}

	//알맞는 시점(다음)에 노트 배치
	void forceDealNotes(NoteJudgeCard shortNoteData, int lineNum)
	{
		GameObject shortNote = poolQueue[lineNum].Dequeue( );  //비활성 풀에서 갓 꺼낸 노트
		shortNote.SetActive(true);  //활성화 (노트 발사)
		activePoolQueue[lineNum].Enqueue(shortNote);
	}
	
	//풀링 오브젝트 회수 메소드(백 투더 풀)
	public void collectObject(GameObject endedNote, int birthQueueNumber)
	{
		poolQueue[birthQueueNumber].Enqueue(endedNote);  //알맞는 큐에 다시 입력(오브젝트 회수)
	}

	//미싱 노트 오브젝트 회수
	public void returnMissingNote(int lineNum)
	{
		GameObject missingShortNote = activePoolQueue[lineNum].Dequeue( );  //활성 풀에서 꺼낸 후
		missingShortNote.transform.position = transform.position;  //위치 초기화 후
		missingShortNote.SetActive(false);  //비활성화
		poolQueue[lineNum].Enqueue(missingShortNote);  //비활성 풀에 넣기
	}

	//가공 데이터 입수
	public void requestRefinedData()
	{
		judgeScroll = (Queue<NoteJudgeCard>[])NoteReferee.instance.judgeScroll.Clone( );
	}
}