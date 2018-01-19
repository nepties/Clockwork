using UnityEngine;
using ClientStates;
using Kaibrary.CallbackModule;
using System.Collections;


namespace InStageScene
{
	public partial class GameManager : MonoBehaviour
	{
		//Ŭ���� ���۷���s
		//���� �Ŵ���
		[SerializeField] InputKeyManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] ResourceManager resourceCtrl;
		

		//sigleTon parts
		public static GameManager instance;
		

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

	public partial class GameManager : MonoBehaviour
	{
		//occur parts : occur-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�������� �غ����� ������ ��-ó�� ( State : read files )
		void forcePreprocess()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceApplyData(); };
			
			//�� ���� �ϳ� �б� ���			
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//���� ���� ���� �� ���� ( State : apply file Data )
		public void forceApplyData()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceLinkTrigger(); };
			
			//�������� �غ� ���
			dataCtrl.exePrepareStage(simpleHandler);
		}

		//�������� ���� Ʈ���� ���� & �ε� ( State : load & link stage trigger )
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
				
				//���� ȸ�� ȣ��� �������� �Ѿ
				if (callingCount == 3)
					forceStageOn(trigger);
			};


			dataCtrl.relayD_loadStage(handler);
			resourceCtrl.relayD_loadStage(handler);
		}

		//���� ���� ( Stage : onStage )
		public void forceStageOn(LightweightDele trigger)
		{
			//   !!SHOWTIME!!
			trigger();
		}

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�ٴ� ȸ�� Ű�Է� ���� & ��� �ϴ�
		public void confNeedleCtrlKeyInput(float rotDegree)
		{
			dataCtrl.exeShortNoteEngage(rotDegree);
			resourceCtrl.relayD_RotateNeedleObject(rotDegree);
		}

		//�ճ�Ʈ Ȱ��ȭ Ű�Է� ���� & ��� �ϴ�
		public void confLongActiveKeyInput()
		{
			dataCtrl.exeLongNoteEngage();
		}

		//�ճ�Ʈ '��'Ȱ��ȭ Ű�Է� ���� & ��� �ϴ�
		public void confLongDeactiveKeyInput()
		{
			dataCtrl.exeLongNoteRelease();
		}
	}
}