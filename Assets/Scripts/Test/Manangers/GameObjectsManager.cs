using UnityEngine;
using System.Collections;

public class GameObjectsManager : MonoBehaviour
{
	ClockNeedle NeedleCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		NeedleCtrl = GameObject.Find("clockNeedle").GetComponent<ClockNeedle>();
	}


	// Update is called once per frame
	void Update()
	{

	}


	//바늘 회전 명령 하달
	public void rotateNeedleObject(float rotDegree)
	{
		NeedleCtrl.rotateNeedle(rotDegree);
	}
}