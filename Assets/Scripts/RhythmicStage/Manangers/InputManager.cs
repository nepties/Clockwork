using UnityEngine;
using RhythmicStage;


namespace RhythmicStage
{
	public class InputManager : MonoBehaviour
	{
		//refs
		//����
		[SerializeField] RhythmicCore coreCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Update is called once per frame
		void Update()
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN


			//����Ʈ ��
			if (Input.GetKeyDown(KeyCode.F))  // FŰ ��Ʈ�� : ���� �� ĭ
				coreCtrl.confNeedleCtrlKeyInput(-1f);

			if (Input.GetKeyDown(KeyCode.D))  // DŰ ��Ʈ�� : ���� �� ĭ
				coreCtrl.confNeedleCtrlKeyInput(-3f);

			if (Input.GetKeyDown(KeyCode.J))  // JŰ ��Ʈ�� : ������ �� ĭ
				coreCtrl.confNeedleCtrlKeyInput(1f);

			if (Input.GetKeyDown(KeyCode.K))  // KŰ ��Ʈ�� : ������ �� ĭ
				coreCtrl.confNeedleCtrlKeyInput(3f);


			//�ճ�Ʈ ��
			if (Input.GetKeyDown("space"))  // �����̽��� ��Ʈ�� : �ճ�Ʈ �Է� Ȱ��ȭ
				coreCtrl.confLongActiveKeyInput();
			if (Input.GetKeyUp("space"))  // : ������ : �ճ�Ʈ �Է� '��'Ȱ��ȭ
				coreCtrl.confLongDeactiveKeyInput();

#else


#endif
		}
	}
}