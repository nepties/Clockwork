﻿using UnityEngine;
using System.Collections.Generic;
using MusicScrolls;
using System.Diagnostics;


namespace InStageScene
{
	public partial class DataManager : ManagerAddOn
	{
		//sigleTon parts
		public static DataManager instance;

		//refs		
		//상위
		[SerializeField] GameManager coreCtrl;  //GM
												//하위
		[SerializeField] NoteReferee refereeCtrl;  //노트 판정확인 클래스
		[SerializeField] fileReader fileDataCtrl;  //파일 정보 수입 클래스

		//노트 관련
		public int needlePhase { get; set; }  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
		public bool isLongactivated { get; set; }  // 롱노트 활성화 여부
		public int curReadingUnit { get; set; }  //현재 읽기 위치 (유닛 단위)
		public int frontReadingUnit { get; set; }  //선행 읽기 위치 (유닛 단위)
		public int initialLoadaAmount { get; set; }  //초기 로딩 노트 수 : 프론트와 커런트 사이 유닛 값

		//배속 관련
		public float curBpm { get; set; }  //현재 재생 곡 BPM
		float speedConstant = 1f;  //배속 상수
		[SerializeField] [Range((0), (10))] float speedMultiplier;  //배속 배수
		public float railSpeed { get; set; }  //레일 스피드 : 최종 노트 속도

		float noteReadDelay;  //bpm에 따른 읽기 지연 시간(단위 : ms)
		float noteReadDelayForSecond;  //bpm에 따른 읽기 지연 시간(단위 : sec)


		//for Test
		Stopwatch stopwatch = GameManager.stopwatch;  //GM 클래스의 스톱워치 받기

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;			

			//초기화 부
			speedMultiplier = 10f;
			curReadingUnit = 0;
			initialLoadaAmount = 20;  //초기 스테이지 배치 유닛 수
			frontReadingUnit = initialLoadaAmount;
			needlePhase = 0;  //최초 바늘 상태에 맞춰
			railSpeed = speedConstant * speedMultiplier;  //최종 배속 설정

		}
	

		//숏노트 처리 관련 메소드
		public void exeShortNoteEngage(float rotateDegree)  //rotateDegree : 1, -1, 3, -3 칸 회전 값(음수값 왼쪽)
		{
			//바늘 방향에 따른 계산 분리
			if (rotateDegree > 0)  //오른쪽 회전일 경우
			{  //숏 노트 판정 실행
				int accessIndex = needlePhase;  //접근할 인덱스 계산 : (x + 3) % 3 = x % 3 = x 

				//알맞는 숏 노트 판정 실행
				refereeCtrl.judgeShortNote(accessIndex, Mathf.Abs((int)rotateDegree));
			}
			else  //왼쪽 회전일 경우
			{  //숏 노트 판정 실행
				int accessIndex = (needlePhase + 2) % 3;  //접근할 인덱스 계산 :  (x + 2) % 3

				//알맞는 숏 노트 판정 실행
				refereeCtrl.judgeShortNote(accessIndex, Mathf.Abs((int)rotateDegree));
			}

			//후 처리
			needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //후에 위치 조정
		}
	}


	public partial class DataManager : ManagerAddOn
	{

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//롱노트 입력 활성화
		public void exeLongNoteEngage()
		{
			isLongactivated = true;
			print("force Long Active");
		}

		//롱노트 입력 비활성화
		public void exeLongNoteRelease()
		{
			isLongactivated = false;
			print("force Long DeActive");
		}

		//report to GM parts : report-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//force from GM parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//곡 하나 읽기 명령 하달(For Test)
		public void relayD_LoadOneFile(messagingDele simpleHandler)
		{
			fileDataCtrl.exeReadOneFullFile();
			print("(GMs)currTick relayD_LoadOneFile() end: " + stopwatch.ElapsedTicks);
		}

		//특정 곡 리딩 완료 : 곡 정보 읽기 완료 최종 확인
		public void relayU_Readfinished()
		{
			print("(GMs)currTick relayU_Readfinished() start: " + stopwatch.ElapsedTicks);
			//GM에게 선곡 정보 전달
			coreCtrl.confMusicData();
		}

		//스테이지 로딩 상태 2 : 변수 초기화 & 노트데이터 재가공
		public void prepareStage()
		{
			//현재 BPM 정보 최초 초기화
			curBpm = fileDataCtrl.metaDataStorage[0].bpm;
			noteReadDelay = 3750f / curBpm; //읽기 지연 시간 초기화
			noteReadDelayForSecond = noteReadDelay / 1000;
			print("first set BPM : " + curBpm);
			print("first set readDelay(ms) : " + noteReadDelay);


			print("(GMs)currTick prepareStage() finish: " + stopwatch.ElapsedTicks);

			//재가공 : 노트 판정을 위한 데이터 큐 제작
			fileDataCtrl.extractJudgeScroll();
		}

		//재가공 데이터 노트판정 객체에게 넘기기 & 스테이지 준비
		public void sendRefineData(Queue<NoteJudgeCard>[] RefineQueue)
		{
			refereeCtrl.receiveRefineData(RefineQueue);
			coreCtrl.dataAllLoaded();  //GM 보고		
		}

		//스테이지 온
		public void stageStarting()
		{
			refereeCtrl.receiveStarting();
		}

		//미싱 노트 받고 인식 from Referee
		public void recognizeMissingNote(int lineNum)
		{
			coreCtrl.receiveMissingNote(lineNum);
		}
	}
}