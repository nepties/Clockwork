using UnityEngine;
using Kaibrary.CallbackModule;
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
		

		//명령 하달 : 바늘 회전
		public void rotateNeedleObject(float rotDegree)
		{
			gameObjectCtrl.relayD_rotateNeedleObject(rotDegree);
		}


		//명령 하달 : 미싱 노트 처리 
		public void sendMissingNote(int lineNum)
		{
			gameObjectCtrl.relayD_treatMissingNote(lineNum);
		}

		//명령 하달 : 스테이지 로딩
		public void relayD_loadStage(reflecMessagingDele handler)
		{
			gameObjectCtrl.relayD_loadStage(handler);
		}
	}

	//상하 명령 메서드 집합
	public partial class GraphicMananger : UnityEngine.MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}