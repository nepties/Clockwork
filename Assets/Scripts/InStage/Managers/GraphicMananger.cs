using UnityEngine;
using System.Collections;


namespace InStageScene
{
	public partial class GraphicMananger : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField] ResourceManager resourceCtrl;
		//하위
		[SerializeField] GameObjectsManager gameObjectCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Start()
		{

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
			gameObjectCtrl.prepareStage();
		}

		//명령 하달 : 미싱 노트 처리 
		public void sendMissingNote(int lineNum)
		{
			gameObjectCtrl.sendMissingNote(lineNum);
		}

		//명령 하달 : 스테이지 시작
		public void sendStageStart()
		{
			gameObjectCtrl.sendStageStart();
		}
	}

	//상하 명령 메서드 집합
	public partial class GraphicMananger : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}