using UnityEngine;
using System.Collections;

public class GraphicMananger : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	ResourceManager resourceCtrl;
	//하위
	GameObjectsManager gameObjectCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//제어 개체 레퍼런스 받아오기
		resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
		gameObjectCtrl = GameObject.Find("GameObjects").GetComponent<GameObjectsManager>();
	}


	// Update is called once per frame
	void Update()
	{

	}


	//명령 하달 : 바늘 회전
	public void rotateNeedleObject(float rotDegree)
	{
		gameObjectCtrl.rotateNeedleObject(rotDegree);
	}

	//명령 하달 : 초기 스테이지 준비!
	public void prepareStage()
	{
		gameObjectCtrl.prepareStage( );
	}
}
