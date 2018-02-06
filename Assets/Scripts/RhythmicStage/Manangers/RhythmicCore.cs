using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;


namespace RhythmicStage
{
	//���� ���� ��� ����
	public partial class RhythmicCore : MonoBehaviour
	{
		//refs
		//�������� Managers
		//[SerializeField] InputManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GameObjectManager objectsCtrl;
		[SerializeField] NoteReferee refereeCtrl;
		[SerializeField] UIManager uiCtrl;

		//sigleTon parts
		public static RhythmicCore instance;		

		//���� ��
		public inRhythmicStageStates State { get; set; }  //�� ����	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//���� ���� ��
			State = inRhythmicStageStates.firstEntry;  //���� ���� : �������� �ε�
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forceimportMusic();  //�������� �ε�
		}		
	}


	//���� ��� �޼��� ����
	public partial class RhythmicCore : MonoBehaviour
	{
		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�������� �غ����� ������ ��-ó�� ( State : read files )
		void forceimportMusic()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceLoadMusicScroll(); };

			//���� ���� ��
			State = inRhythmicStageStates.firstEntry;
			//�ϴ� : �� ���� ����
			dataCtrl.relayD_importMusic(simpleHandler);
		}

		//���� ���� ���� �� ���� ( State : apply file Data )
		public void forceLoadMusicScroll()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceLinkTrigger(); };

			//���� ���� ��
			State = inRhythmicStageStates.enteringStage;
			//�ϴ� : �������� �غ� ���
			dataCtrl.exeLoadMusicScroll(simpleHandler);
		}

		//�������� ���� Ʈ���� ���� & �ε� ( State : load & link stage trigger )
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

				//���� ȸ�� ȣ��� �������� �Ѿ
				if (callingCount == 3)
					forceStageOn(trigger);  //�ε� �Ϸ�
			};

			//�ϴ� : ���� �غ�			
			soundCtrl.exeLinkTrigger(handler);
			objectsCtrl.relayD_LinkTriggerNLoad(handler);
			refereeCtrl.exeLinkTriggerNLoad(handler);
		}

		//���� ���� ( Stage : onStage )
		public void forceStageOn(LightweightHandler trigger)
		{
			//   !!SHOWTIME!!
			trigger();

			//���� ���� ��
			State = inRhythmicStageStates.stageOn;
		}


		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�Է� ����
		public void confShortInput(int InputChannel)
		{
			refereeCtrl.exeReferActivation(InputChannel);
			objectsCtrl.relayD_ShortInput(InputChannel);			
		}

		//������ ����
		public void confLongDeactivate(int InputChannel)
		{
			refereeCtrl.exeReferDeActivation(InputChannel);
			objectsCtrl.relayD_LongDeactivate(InputChannel);
		}

		//�̽� ��Ʈ ����
		public void confMissingNote(int channel)
		{
			objectsCtrl.relayD_treatMissingNote(channel);
		}

		//�� ��Ʈ ���� ��� ����
		public void confShortNoteJudge(int channel, noteJudgement judgement)
		{
			objectsCtrl.relayD_ShortNoteJudge(channel, judgement);
		}
	}
}