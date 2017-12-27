using UnityEngine;
using ClientStates;
using System.Collections;
using System.Diagnostics;


namespace InStageScene
{
	public partial class GameManager : ManagerAddOn
	{
		//클래스 레퍼런스s
		//하위 매니저
		[SerializeField] InputKeyManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] ResourceManager resourceCtrl;


		//sigleTon parts
		public static GameManager instance;

		//스톱 워치
		public static Stopwatch stopwatch = new Stopwatch();

		//상태 계
		public inStageStates gameState { get; set; }  //현 상태	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//상태 설정 부
			gameState = inStageStates.enteringStage;  //최초 상태 : 스테이지 로딩
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			forcePreprocess();  //스테이지 로딩
		}
		

		//스테이지 준비 관련 데이터 처리 모두 완료(바로 스테이지 온)
		public void dataAllLoaded()
		{
			dataCtrl.stageStarting();
			resourceCtrl.stageStarting();
		}

		//미싱 노트 관련 처리
		public void receiveMissingNote(int lineNum)
		{
			resourceCtrl.sendMissingNote(lineNum);
		}
	}

	public partial class GameManager : ManagerAddOn
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//스테이지 준비직전 데이터 선-처리
		void forcePreprocess()
		{
			messagingDele simpleHandler;
			//곡 정보 하나 읽기 명령
			stopwatch.Start();  //시간측정 시작!
			print("START POINT :: for Test, force stage Loading...");
			print("(GMs)currTick : " + stopwatch.ElapsedTicks);

			//곡 하나 읽어들이기
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//바늘 회전 키입력 감지 & 명령 하달
		public void confNeedleCtrlKeyInput(float rotDegree)
		{
			dataCtrl.exeShortNoteEngage(rotDegree);
			resourceCtrl.forceRotateNeedleObject(rotDegree);
		}

		//롱노트 활성화 키입력 감지 & 명령 하달
		public void confLongActiveKeyInput()
		{
			dataCtrl.exeLongNoteEngage();
		}

		//롱노트 '비'활성화 키입력 감지 & 명령 하달
		public void confLongDeactiveKeyInput()
		{
			dataCtrl.exeLongNoteRelease();
		}

		//선곡 정보 받은 후 동작 (상태 변화 : load completed)
		public void confMusicData()
		{
			dataCtrl.prepareStage();
		}
	}
}