using UnityEngine;
using System.Collections.Generic;
using MusicScrolls;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


namespace InStageScene
{
	public class NoteReferee : MonoBehaviour
	{
		//sigleTon parts
		public static NoteReferee instance;

		//클래스 레퍼런스s
		//직속 매니저(상위)
		[SerializeField] DataManager DataCtrl;

		public Queue<NoteJudgeCard>[] judgeScroll { get; set; }  //각 라인에 노트 판정을 위한 노트배치표 큐
		[SerializeField] float perfectJudgeflexibility = 200f;  //판정 상수(ms)
		[SerializeField] float niceJudgeflexibility = 450f;  //판정 상수(ms)
		[SerializeField] float judgeFactor;  //판정 배수(널널함, 엄격함)

		//스톱 워치
		public static Stopwatch stopwatch = new Stopwatch();

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;
			judgeFactor = 1.0f;
		}

		// Update is called once per frame
		void Update()
		{
			/*
			foreach(Queue<NoteJudgeCard> judgeLine in judgeScroll)
			{
				//나이스 판정 시간대보다 뒤에 있는경우
				if(judgeLine.Peek().time < stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
				{
					// Miss 처리
					judgeLine.Dequeue( );
					Debug.Log("Miss...");
				}
			}
		
			for(int i = 0; i < 12; i++)
			{
				Queue<NoteJudgeCard> judgeLine = judgeScroll[i];

				//나이스 판정 시간대보다 뒤에 있는경우
				if(judgeLine.Peek().time < stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
				{
					// Miss 처리
					judgeLine.Dequeue( );  //큐에서 제외
					treatMissingNote(i);  //해당 노트 관련 처리 푸시
					Debug.Log("Miss...");
				}
			}
			*/
		}

		//숏노트 판정 실행
		public void judgeShortNote(int LineNum, int noteType)
		{
			//먼저 퍼펙트 여부 확인
			if (judgeScroll[LineNum].Peek().time < stopwatch.ElapsedMilliseconds + perfectJudgeflexibility && judgeScroll[LineNum].Peek().time > stopwatch.ElapsedMilliseconds - perfectJudgeflexibility)
			{
				//퍼팩트 처리 (판정 1)
				Debug.Log("PERFECT!!");
			}
			//그 다음 나이스 처리			
			else if (judgeScroll[LineNum].Peek().time <= stopwatch.ElapsedMilliseconds + niceJudgeflexibility && judgeScroll[LineNum].Peek().time >= stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
			{
				//나이스 처리 (판정 2)
				Debug.Log("Nice");
			}
		}

		//롱노트 판정 실행
		public void judgeLongNote()
		{

		}

		//가공 데이터 수입
		public void receiveRefineData(Queue<NoteJudgeCard>[] RefineQueue)
		{
			judgeScroll = RefineQueue;
		}

		//무대 쇼타임 시작
		public void receiveStarting()
		{
			//시간 측정
			stopwatch.Start();
		}

		//무대 막 내리기
		public void receiveEnding()
		{
			//시간 멈춤
			stopwatch.Stop();
		}

		//미싱 노트 처리 관련
		public void treatMissingNote(int lineNum)
		{
			DataCtrl.recognizeMissingNote(lineNum);
		}
	}
}