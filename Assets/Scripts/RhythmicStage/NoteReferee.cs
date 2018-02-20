using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;
using System.Diagnostics;
using UnityEditor;



namespace RhythmicStage
{
	public partial class NoteReferee : MonoBehaviour
	{

		//refs
		//immediate Manager(상위)
		[SerializeField] RhythmicCore coreCtrl;
		//LocalStorage
		[SerializeField] LocalStorage dataCtrl;

		//sigleTon parts
		public static NoteReferee instance;

		//노트 관련
		public int needlePhase { get; set; }  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
		public bool isLongActivated { get; set; }  // 롱노트 활성화 여부
		public int curReadingUnit { get; set; }  //현재 읽기 위치 (유닛 단위)
		//public int frontReadingUnit { get; set; }  //선행 읽기 위치 (유닛 단위)
		//public int initialLoadaAmount { get; set; }  //초기 로딩 노트 수 : 프론트와 커런트 사이 유닛 값

		//Fields
		public Queue<NoteJudgeCard>[] judgeScroll { get; set; }  //각 라인에 노트 판정을 위한 노트배치표 큐
		[SerializeField] const float perfectJudgeflexibility = 200f;  //판정 상수(ms)
		[SerializeField] const float niceJudgeflexibility = 250f;  //판정 상수(ms)
		[SerializeField] float judgeFactor;  //판정 배수(널널함, 엄격함 결정)

		//스톱 워치
		public static Stopwatch stopwatch = new Stopwatch();

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;


			//초기화 부
			//speedMultiplier = 10f;
			curReadingUnit = 0;
			//initialLoadaAmount = 20;  //초기 스테이지 배치 유닛 수
			//frontReadingUnit = initialLoadaAmount;
			needlePhase = 0;  //최초 바늘 상태에 맞춰
			//railSpeed = SPEEDCONST * speedMultiplier;  //최종 배속 설정

			judgeFactor = 1.0f;

			EditorApplication.pauseStateChanged += pauseStopWatch;
		}

		// Update is called once per frame
		void Update()
		{		
			for(int row = 0; row < dataCtrl.shortNoteChannel; row++)
			{
				try
				{
					//나이스 판정 시간대보다 뒤에 있는경우
					if (judgeScroll[row].Peek().time < stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
					{
						// Miss 처리
						judgeScroll[row].Dequeue();  //큐에서 제외
						occurTreatMissingNote(row);  //해당 노트 관련 처리 푸시
						print("Miss...");
					}
				}
				catch (InvalidOperationException)
				{ }
			}			
		}

		//숏노트 판정 실행
		void judgeShortNote(int InputChannel)
		{
			try
			{ 
				//먼저 퍼펙트 여부 확인
				if (judgeScroll[InputChannel].Peek().time < stopwatch.ElapsedMilliseconds + perfectJudgeflexibility
					&&
				judgeScroll[InputChannel].Peek().time > stopwatch.ElapsedMilliseconds - perfectJudgeflexibility)
				{
					//퍼팩트 처리 (판정 1)
					judgeScroll[InputChannel].Dequeue();
					occurShortNoteJudge(InputChannel, noteJudgement.perfect);
					print("PERFECT!! " + "[ " + stopwatch.ElapsedMilliseconds + " ]");
				}

				//그 다음 나이스 처리			
				else if (judgeScroll[InputChannel].Peek().time <= stopwatch.ElapsedMilliseconds + niceJudgeflexibility
					&&
				judgeScroll[InputChannel].Peek().time >= stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
				{
					//나이스 처리 (판정 2)
					judgeScroll[InputChannel].Dequeue();
					occurShortNoteJudge(InputChannel, noteJudgement.nice);
					print("Nice " + "[ " + stopwatch.ElapsedMilliseconds + " ]");
				}
			}
			catch(InvalidOperationException)
			{ }			
		}

		//숏노트 판정 실행
		public void judgeShortNote(int LineNum, int noteType)
		{
			try
			{
				//먼저 퍼펙트 여부 확인
				if (judgeScroll[LineNum].Peek().time < stopwatch.ElapsedMilliseconds + perfectJudgeflexibility && 
					judgeScroll[LineNum].Peek().time > stopwatch.ElapsedMilliseconds - perfectJudgeflexibility)
				{
					//퍼팩트 처리 (판정 1)
					judgeScroll[LineNum].Dequeue();
					occurShortNoteJudge(LineNum, noteJudgement.perfect);
					print("PERFECT!! " + "[ " + stopwatch.ElapsedMilliseconds + " ]");
					// ▨ 보안 요소 : 4개의 인덱스에 대해 동시 판정
				}
				//그 다음 나이스 처리			
				else if (judgeScroll[LineNum].Peek().time <= stopwatch.ElapsedMilliseconds + niceJudgeflexibility &&
					judgeScroll[LineNum].Peek().time >= stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
				{
					//나이스 처리 (판정 2)
					judgeScroll[LineNum].Dequeue();
					occurShortNoteJudge(LineNum, noteJudgement.nice);
					print("Nice " + "[ " + stopwatch.ElapsedMilliseconds + " ]");
					// ▨ 보안 요소 : 4개의 인덱스에 대해 동시 판정
				}
			}
				catch (InvalidOperationException)
			{ }
		}

		//스톱워치 시간 출력
		void OnGUI()
		{
			GUI.Label(new Rect(300, 20, 200, 20), "StageTimer : " + stopwatch.ElapsedMilliseconds.ToString());
		}

		//에디터 일시정지 시 스톱워치 제어
		void pauseStopWatch(PauseState state)
		{
			if (state == PauseState.Paused)			
				stopwatch.Stop();
							
			else			
				stopwatch.Start();
							
		}

		//롱노트 판정 실행
		void judgeLongNote()
		{
			//▨ 구현 예정
		}

		//롱노트 입력 활성화
		public void exeLongNoteEngage()
		{
			isLongActivated = true;
			print("force Long Active");
		}

		//롱노트 입력 비활성화
		public void exeLongNoteRelease()
		{
			isLongActivated = false;
			print("force Long DeActive");
		}

		//무대 쇼타임 시작
		void exeShowTime()
		{
			//시간 측정
			stopwatch.Start();
			print("time checking start");
		}

		//무대 막 내리기
		void exeEndStage()
		{
			//시간 멈춤
			stopwatch.Stop();
		}

		//숏노트 처리 관련 메소드
		public void exeShortNoteEngage(float rotateDegree)  //rotateDegree : 1, -1, 3, -3 칸 회전 값(음수값 왼쪽)
		{
			//바늘 방향에 따른 계산 분리
			if (rotateDegree > 0)  //오른쪽 회전일 경우
			{  //숏 노트 판정 실행
				int accessIndex = needlePhase;  //접근할 인덱스 계산 : (x + 3) % 3 = x % 3 = x 

				//알맞는 숏 노트 판정 실행
				judgeShortNote(accessIndex, Mathf.Abs((int)rotateDegree));
			}
			else  //왼쪽 회전일 경우
			{  //숏 노트 판정 실행
				int accessIndex = (needlePhase + 2) % 3;  //접근할 인덱스 계산 :  (x + 2) % 3

				//알맞는 숏 노트 판정 실행
				judgeShortNote(accessIndex, Mathf.Abs((int)rotateDegree));
			}

			//후 처리
			needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //후에 위치 조정
		}
	}


	//상하 명령 메서드 집합
	public partial class NoteReferee : MonoBehaviour
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//미스 노트 처리 관련
		public void occurTreatMissingNote(int channel)
		{
			coreCtrl.confMissingNote(channel);
		}

		//숏노트 판정 결과 발생
		public void occurShortNoteJudge(int channel, noteJudgement judgement)
		{
			coreCtrl.confShortNoteJudge(channel, judgement);
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//트리거 연결
		public void exeLinkTriggerNLoad(reflecMessagingHandler Handler)
		{
			//데이터 수입 부
			judgeScroll = dataCtrl.judgeScroll;

			//로드 완료
			Handler("Referee : get a linker!", exeShowTime);
		}

		//노트 입력 시작 감지
		public void exeReferActivation(int Channel)
		{
			judgeShortNote(Channel);
		}

		//노트 지속 입력 릴리즈 감지
		public void exeReferDeActivation(int Channel)
		{

		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-		
	}
}