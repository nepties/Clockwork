using UnityEngine;
using System.Collections.Generic;
using ReferenceSetting;
using MusicScrolls;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class NoteReferee : MonoBehaviour
{
	//클래스 레퍼런스s
	//직속 매니저
	[SerializeField] DataManager DataCtrl;

	Queue<NoteJudgeCard> [] judgeScroll;  //각 라인에 노트 판정을 위한 노트배치표 큐
	[SerializeField] float perfectJudgeflexibility = 40f;  //판정 상수(ms)
	[SerializeField] float niceJudgeflexibility = 80f;  //판정 상수(ms)
	[SerializeField] float judgeMultiple;  //판정 배수(널널함, 엄격함)	
	
	//스톱 워치
	public static Stopwatch stopwatch = new Stopwatch( );
	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Awake()
	{
		
	}

	// Update is called once per frame
	void Update()
	{		
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
	}

	//숏노트 판정 실행
	public void judgeShortNote(int LineNum, int noteType)
	{
		//먼저 퍼펙트 여부 확인
		if(judgeScroll[LineNum].Peek().time < stopwatch.ElapsedMilliseconds + perfectJudgeflexibility && judgeScroll[LineNum].Peek().time > stopwatch.ElapsedMilliseconds - perfectJudgeflexibility)
		{
			//퍼팩트 처리 (판정 1)
			Debug.Log("PERFECT!!");
		}			
		else if(judgeScroll[LineNum].Peek().time <= stopwatch.ElapsedMilliseconds + niceJudgeflexibility && judgeScroll[LineNum].Peek().time >= stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
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
	public void receiveRefineData(Queue<NoteJudgeCard> [] RefineQueue)
	{
		judgeScroll = RefineQueue;
	}

	//무대 쇼타임 시작
	public void receiveStarting( )
	{
		//시간 측정
		stopwatch.Start( );
	}

	//무대 막 내리기
	public void receiveEnding()
	{
		//시간 멈춤
		stopwatch.Stop( );
	}
}



