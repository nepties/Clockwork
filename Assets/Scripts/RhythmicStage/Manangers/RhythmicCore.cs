using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;


namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class RhythmicCore : MonoBehaviour
	{
		//refs
		//직속하위 Managers
		//[SerializeField] InputManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GameObjectManager objectsCtrl;
		[SerializeField] NoteReferee refereeCtrl;
		[SerializeField] UIManager uiCtrl;

		//sigleTon parts
		public static RhythmicCore instance;		

		//상태 계
		public inRhythmicStageStates State { get; set; }  //현 상태	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//상태 설정 부
			State = inRhythmicStageStates.firstEntry;  //최초 상태 : 스테이지 로딩
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forceimportMusic();  //스테이지 로딩
		}		
	}


	//상하 명령 메서드 집합
	public partial class RhythmicCore : MonoBehaviour
	{
		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//스테이지 준비직전 데이터 선-처리 ( State : read files )
		void forceimportMusic()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceLoadMusicScroll(); };

			//상태 설정 부
			State = inRhythmicStageStates.firstEntry;
			//하달 : 곡 정보 수입
			dataCtrl.relayD_importMusic(simpleHandler);
		}

		//선곡 정보 받은 후 동작 ( State : apply file Data )
		public void forceLoadMusicScroll()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceLinkTrigger(); };

			//상태 설정 부
			State = inRhythmicStageStates.enteringStage;
			//하달 : 스테이지 준비 명령
			dataCtrl.exeLoadMusicScroll(simpleHandler);
		}

		//스테이지 시작 트리거 연결 & 로딩 ( State : load & link stage trigger )
		public void forceLinkTrigger()
		{
			reflecMessagingHandler handler = null;
			LightweightHandler trigger = null;
			
			int callingCount = 0;
			handler = (string st, LightweightHandler recall) =>
			{
				callingCount++;
				print(st + "[" + callingCount + "]");
				trigger += recall;

				//일정 회수 호출시 다음으로 넘어감
				if (callingCount == 3)
					forceStageOn(trigger);  //로딩 완료
			};

			//하달 : 최종 준비			
			soundCtrl.exeLinkTrigger(handler);
			objectsCtrl.relayD_LinkTriggerNLoad(handler);
			refereeCtrl.exeLinkTriggerNLoad(handler);
		}

		//무대 시작 ( Stage : onStage )
		public void forceStageOn(LightweightHandler trigger)
		{
			//   !!SHOWTIME!!
			trigger();

			//상태 설정 부
			State = inRhythmicStageStates.stageOn;
		}


		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//입력 감지
		public void confShortInput(int InputChannel)
		{
			refereeCtrl.exeReferActivation(InputChannel);
			objectsCtrl.relayD_ShortInput(InputChannel);			
		}

		//릴리즈 감지
		public void confLongDeactivate(int InputChannel)
		{
			refereeCtrl.exeReferDeActivation(InputChannel);
			objectsCtrl.relayD_LongDeactivate(InputChannel);
		}

		//미싱 노트 감지
		public void confMissingNote(int channel)
		{
			objectsCtrl.relayD_treatMissingNote(channel);
		}

		//숏 노트 판정 결과 감지
		public void confShortNoteJudge(int channel, noteJudgement judgement)
		{
			objectsCtrl.relayD_ShortNoteJudge(channel, judgement);
		}
	}
}