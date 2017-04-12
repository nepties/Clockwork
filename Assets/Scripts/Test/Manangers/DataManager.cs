using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour
{
	GameManager coreCtrl;

	[SerializeField]
	int needlePhase;  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
	bool isLongactivated;  // 롱노트 활성화 여부

	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();
	}
	

	// Update is called once per frame
	void Update()
	{
	
	}


	//바늘 회전 메소드
	public void rotateNeedleData(float rotateDegree)  // rotateDegree : 1, -1, 3, -3 칸 회전 값
	{
		needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //바늘 위치 단계 계산
	}
	
	//롱노트 입력 활성화 정보 수정
	public void LongNoteEngage()
	{
		isLongactivated = true;
		Debug.Log("force Long Active");
	}

	//롱노트 입력 활성화 정보 수정
	public void LongNoteRelease()
	{
		isLongactivated = false;
		Debug.Log("force Long DeActive");
	}
}
