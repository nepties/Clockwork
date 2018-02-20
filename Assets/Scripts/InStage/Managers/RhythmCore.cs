using UnityEngine;
using ClientStates;
using ClockCore;
using System.Collections;


namespace InStageScene
{
	public partial class RhythmCore : MonoBehaviour
	{
		//Ŭ���� ���۷���s
		//���� �Ŵ���
		[SerializeField] InputKeyManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] ResourceManager resourceCtrl;
		

		//sigleTon parts
		public static RhythmCore instance;
		

		//���� ��
		public inStageStates gameState { get; set; }  //�� ����	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//���� ���� ��
			gameState = inStageStates.enteringStage;  //���� ���� : �������� �ε�
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forcePreprocess();  //�������� �ε�
		}

		//�̽� ��Ʈ ���� ó��
		public void receiveMissingNote(int lineNum)
		{
			resourceCtrl.relayD_MissingNote(lineNum);
		}
	}

	public partial class RhythmCore : MonoBehaviour
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�������� �غ����� ������ ��-ó�� ( State : read files )
		void forcePreprocess()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceApplyData(); };
			
			//�� ���� �ϳ� �б� ����			
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//���� ���� ���� �� ���� ( State : apply file Data )
		public void forceApplyData()
		{
			messagingHandler simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceLinkTrigger(); };
			
			//�������� �غ� ����
			dataCtrl.exePrepareStage(simpleHandler);
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
				print(st + "||" + callingCount);
				trigger += recall;
				
				//���� ȸ�� ȣ��� �������� �Ѿ
				if (callingCount == 3)
					forceStageOn(trigger);
			};


			dataCtrl.relayD_loadStage(handler);
			resourceCtrl.relayD_loadStage(handler);
		}

		//���� ���� ( Stage : onStage )
		public void forceStageOn(LightweightHandler trigger)
		{
			//   !!SHOWTIME!!
			trigger();
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�ٴ� ȸ�� Ű�Է� ���� & ���� �ϴ�
		public void confNeedleCtrlKeyInput(float rotDegree)
		{
			dataCtrl.exeShortNoteEngage(rotDegree);
			resourceCtrl.relayD_RotateNeedleObject(rotDegree);
		}

		//�ճ�Ʈ Ȱ��ȭ Ű�Է� ���� & ���� �ϴ�
		public void confLongActiveKeyInput()
		{
			dataCtrl.exeLongNoteEngage();
		}

		//�ճ�Ʈ '��'Ȱ��ȭ Ű�Է� ���� & ���� �ϴ�
		public void confLongDeactiveKeyInput()
		{
			dataCtrl.exeLongNoteRelease();
		}
	}
}