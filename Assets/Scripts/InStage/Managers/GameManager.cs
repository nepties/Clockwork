using UnityEngine;
using ClientStates;
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

		//상태 계
		public inStageStates gameState { get; set; }  //현 상태	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
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

	public partial class GameManager : MonoBehaviour
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//스테이지 준비직전 데이터 선-처리
		void forcePreprocess()
		{
			//곡 정보 하나 읽기 명령
			print("Music selected, force stage Loading...");
			//곡 하나 읽어들이기
			dataCtrl.relayD_LoadOneFile();
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//바늘 회전 키입력 감지 & 명령 하달
		public void confNeedleCtrlKeyInput(float rotDegree)
		{
			dataCtrl.rotateNeedleData(rotDegree);
			resourceCtrl.rotateNeedleObject(rotDegree);
		}

		//롱노트 활성화 키입력 감지 & 명령 하달
		public void confLongActiveKeyInput()
		{
			dataCtrl.LongNoteEngage();
		}

		//롱노트 '비'활성화 키입력 감지 & 명령 하달
		public void confLongDeactiveKeyInput()
		{
			dataCtrl.LongNoteRelease();
		}

		//선곡 정보 받은 후 동작 (상태 변화 : load completed)
		public void confMusicData()
		{
			dataCtrl.prepareStage();
		}
	}
}