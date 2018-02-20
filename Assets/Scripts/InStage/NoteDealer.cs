using ClockCore;
using Kaibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



namespace InStageScene
{
	public partial class NoteDealer : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] GameObjectsManager gameObjectCtrl;


		[SerializeField] GameObject noteObject;  //숏 노트 오브젝트	
		int poolSize;  //오브젝트 풀 최대 수용량

		//오브젝트 풀 레퍼런스
		Queue<GameObject>[] poolQueue;  //비활성 오브젝트 대기큐
		Queue<GameObject>[] activePoolQueue;  //활성 오브젝트 관리큐

		//기타
		Queue<NoteJudgeCard>[] judgeScroll;  //복사본(임시)
		Stopwatch stopwatch = NoteReferee.stopwatch;  //노트 딜러 클래스의 스톱워치 받기
		float preLoadingTime;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//초기, 임의값 초기화 부
			poolSize = 20;  //생성량 초기설정값		
			preLoadingTime = 500f;  //프리로딩

			//비활성 오브젝트 대기큐 배열 생성 부
			poolQueue = new Queue<GameObject>[12];
			for (int i = 0; i < 12; i++)  //12개 대기열
			{
				poolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
			}

			//활성 오브젝트 관리큐 배열 생성 부
			activePoolQueue = new Queue<GameObject>[12];
			for (int i = 0; i < 12; i++)  //12개 대기열
			{
				activePoolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
			}

			//오브젝트 생성 부
			createNoteObject();
			//로드 완료		
		}

		// Update is called once per frame
		void Update()
		{
			//숏노트 프리로딩
			for (int i = 0; i < 12; i++)
			{
				Queue<NoteJudgeCard> judgeLine = judgeScroll[i];

				try
				{

					//프리로드 시점에 걸친 노트 발견
					if (judgeLine.Peek().time <= stopwatch.ElapsedMilliseconds + preLoadingTime)
					{
						dealNotes(judgeLine.Dequeue(), i);  //큐에서 제외
						print("Pop ShortNote! __ PreLoading ( " + (stopwatch.ElapsedMilliseconds + preLoadingTime) + " ) corr : " + stopwatch.ElapsedMilliseconds);
					}

				} //try close

				catch (InvalidOperationException)
				{

				}
			}
		}

		//풀링할 오브젝트 생성 메소드
		void createNoteObject()
		{
			//설정 수 만큼 생성 부
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < poolSize; j++)
				{
					GameObject creation = (GameObject)Instantiate(noteObject, this.transform.position, Quaternion.identity);  //오브젝트 생성
					creation.transform.Rotate(i * -30f * Vector3.forward);  //알맞게 회전
					creation.SetActive(false);  //비활성화				
												//creation.GetComponent<NoteObjectMethod>( ).setQueueNumber(i);  //출신 대기큐 번호 부여
					poolQueue[i].Enqueue(creation);  //오브젝트를 대기큐 입력
				}
			}
		}

		//알맞는 시점(다음)에 노트 배치
		void dealNotes(NoteJudgeCard shortNoteData, int lineNum)
		{
			GameObject shortNote = poolQueue[lineNum].Dequeue();  //비활성 풀에서 갓 꺼낸 노트
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
			GameObject missingShortNote = activePoolQueue[lineNum].Dequeue();  //활성 풀에서 꺼낸 후
			missingShortNote.transform.position = transform.position;  //위치 초기화 후
			missingShortNote.SetActive(false);  //비활성화
			poolQueue[lineNum].Enqueue(missingShortNote);  //비활성 풀에 넣기
		}

		//스테이지 로딩
		public void exeloadStage(reflecMessagingHandler handler)
		{
			judgeScroll = fileReader.instance.copyRefinedQueue();
			handler("Dealer : im ready!!", null);
		}
	}

	public partial class NoteDealer : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}