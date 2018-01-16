using UnityEngine;
using Kaibrary.CallbackModule;
using System.Collections;


namespace InStageScene
{
	public partial class GameObjectsManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField] GraphicMananger graphicCtrl;
		//하위
		[SerializeField] ClockNeedle NeedleCtrl;
		[SerializeField] NoteDealer noteObjectPoolCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-		

	}

	//상하 명령 메서드 집합
	public partial class GameObjectsManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//노트풀에 미싱 노트 처리 명령
		public void relayD_treatMissingNote(int lineNum)
		{
			noteObjectPoolCtrl.returnMissingNote(lineNum);
		}

		//명령 하달 : 스테이지 로딩
		public void relayD_loadStage(reflecMessagingDele handler)
		{
			noteObjectPoolCtrl.exeloadStage(handler);
		}

		//명령 하달 : 바늘 회전
		public void relayD_rotateNeedleObject(float rotDegree)
		{
			NeedleCtrl.rotateNeedle(rotDegree);
		}
	}
}