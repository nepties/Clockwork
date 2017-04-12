using UnityEngine;
using System.Collections;

public class GraphicMananger : MonoBehaviour
{
	ResourceManager resourceCtrl;
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


	//바늘 회전 명령 하달
	public void rotateNeedleObject(float rotDegree)
	{
		gameObjectCtrl.rotateNeedleObject(rotDegree);
	}
}
