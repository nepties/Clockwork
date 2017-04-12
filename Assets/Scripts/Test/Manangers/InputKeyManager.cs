using UnityEngine;
using System.Collections;

public class InputKeyManager : MonoBehaviour
{
	GameManager coreCtrl;

	public string steerObjectName = "clockNeedle";  // clockNeedle 오브젝트 이름	
	GameObject steerObject;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
		steerObject = GameObject.Find(steerObjectName);  //조정 오브젝트 이름으로 찾기
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))  // 스페이스바 스트록 : 롱노트 입력 활성화
			coreCtrl.longActiveKeyInput();
		if (Input.GetKeyUp("space"))  // : 릴리즈 : 롱노트 입력 '비'활성화
			coreCtrl.longDeactiveKeyInput();

		if (Input.GetKeyDown(KeyCode.F))  // F키 스트록 : 왼쪽 한 칸
			coreCtrl.NeedleCtrlKeyInput(-1f);

		if (Input.GetKeyDown(KeyCode.D))  // D키 스트록 : 왼쪽 세 칸
			coreCtrl.NeedleCtrlKeyInput(-3f);

		if (Input.GetKeyDown(KeyCode.J))  // J키 스트록 : 오른쪽 한 칸
			coreCtrl.NeedleCtrlKeyInput(1f);

		if (Input.GetKeyDown(KeyCode.K))  // K키 스트록 : 오른쪽 한 칸
			coreCtrl.NeedleCtrlKeyInput(3f);
	}
}