using UnityEngine;


namespace InStageScene
{
	public class InputKeyManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField]
		GameManager coreCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{

		}

		// Update is called once per frame
		void Update()
		{
			//숏노트 계
			if (Input.GetKeyDown(KeyCode.F))  // F키 스트록 : 왼쪽 한 칸
				coreCtrl.NeedleCtrlKeyInput(-1f);

			if (Input.GetKeyDown(KeyCode.D))  // D키 스트록 : 왼쪽 세 칸
				coreCtrl.NeedleCtrlKeyInput(-3f);

			if (Input.GetKeyDown(KeyCode.J))  // J키 스트록 : 오른쪽 한 칸
				coreCtrl.NeedleCtrlKeyInput(1f);

			if (Input.GetKeyDown(KeyCode.K))  // K키 스트록 : 오른쪽 한 칸
				coreCtrl.NeedleCtrlKeyInput(3f);


			//롱노트 계
			if (Input.GetKeyDown("space"))  // 스페이스바 스트록 : 롱노트 입력 활성화
				coreCtrl.longActiveKeyInput();
			if (Input.GetKeyUp("space"))  // : 릴리즈 : 롱노트 입력 '비'활성화
				coreCtrl.longDeactiveKeyInput();
		}
	}
}