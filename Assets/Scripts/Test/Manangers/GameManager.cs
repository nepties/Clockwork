using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	InputKeyManager inputCtrl;
	DataManager dataCtrl;
	ResourceManager resourceCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//제어 개체 레퍼런스 받아오기
		inputCtrl = GameObject.Find("KeyInputMananger").GetComponent<InputKeyManager>();
		dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>();
		resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
	}	

	// Update is called once per frame
	void Update ()
	{
		
	}


	//바늘 회전 키입력 감지 & 명령 하달
	public void NeedleCtrlKeyInput(float rotDegree)
	{
		dataCtrl.rotateNeedleData(rotDegree);
		resourceCtrl.rotateNeedleObject(rotDegree);
	}
}
