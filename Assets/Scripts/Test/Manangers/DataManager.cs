using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour
{
	GameManager coreCtrl;

	[SerializeField]
	int needlePhase;  // 0, 1, 2  :  phase 3 바늘 위치 상태 값
	float currentDegree;  //현재 회전 각도	
	float targetDegree;  //회전 목표 각도

	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>();

		targetDegree = 0f;
		currentDegree = 0f;
	}
	

	// Update is called once per frame
	void Update()
	{
	
	}


	//바늘 회전 메소드
	public void rotateNeedleData(float rotateDegree)  // rotateDegree : 1, -1, 3, -3 칸 회전 값
	{
		needlePhase = (needlePhase + 3 + (int)rotateDegree) % 3;  //바늘 위치 단계 계산
		targetDegree = targetDegree + rotateDegree * -30f;  //목표 회전 각도 계산
		//transform.Rotate(Vector3.right * rotateDegree);
	}

}
