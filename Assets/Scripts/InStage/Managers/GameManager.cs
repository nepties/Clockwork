using UnityEngine;
using ClientStates;
using Kaibrary.CallbackModule;
using System.Collections;


namespace InStageScene
{
	public partial class GameManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//하위 매니저
		[SerializeField] InputKeyManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] ResourceManager resourceCtrl;
		

		//sigleTon parts
		public static GameManager instance;
		

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
			//!!Stage START POINT!!
			forcePreprocess();  //스테이지 로딩
		}

		//미싱 노트 관련 처리
		public void receiveMissingNote(int lineNum)
		{
			resourceCtrl.relayD_MissingNote(lineNum);
		}
	}

	public partial class GameManager : MonoBehaviour
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//스테이지 준비직전 데이터 선-처리 ( State : read files )
		void forcePreprocess()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceApplyData(); };
			
			//곡 정보 하나 읽기 명령			
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//선곡 정보 받은 후 동작 ( State : apply file Data )
		public void forceApplyData()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceLinkTrigger(); };
			
			//스테이지 준비 명령
			dataCtrl.exePrepareStage(simpleHandler);
		}

		//스테이지 시작 트리거 연결 & 로딩 ( State : load & link stage trigger )
		public void forceLinkTrigger()
		{
			reflecMessagingDele handler = null;
			LightweightDele trigger = null;
			int callingCount = 0;
			handler = (string st, LightweightDele recall) => 
			{
				callingCount++;
				print(st + "||" + callingCount);
				trigger += recall;
				
				//일정 회수 호출시 다음으로 넘어감
				if (callingCount == 3)
					forceStageOn(trigger);
			};


			dataCtrl.relayD_loadStage(handler);
			resourceCtrl.relayD_loadStage(handler);
		}

		//무대 시작 ( Stage : onStage )
		public void forceStageOn(LightweightDele trigger)
		{
			//   !!SHOWTIME!!
			trigger();
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//바늘 회전 키입력 감지 & 명령 하달
		public void confNeedleCtrlKeyInput(float rotDegree)
		{
			dataCtrl.exeShortNoteEngage(rotDegree);
			resourceCtrl.relayD_RotateNeedleObject(rotDegree);
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
	}
}