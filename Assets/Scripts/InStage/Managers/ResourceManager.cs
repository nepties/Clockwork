using UnityEngine;
using Kaibrary.CallbackModule;
using System.Collections;


namespace InStageScene
{
	public partial class ResourceManager : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] GraphicMananger graphicCtrl;
		[SerializeField] SoundManager soundCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
	}


	//상하 명령 메서드 집합
	public partial class ResourceManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_- or force
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//명령 하달 : 스테이지 시작
		public void relayD_loadStage(reflecMessagingDele handler)
		{
			graphicCtrl.relayD_loadStage(handler);
			soundCtrl.reportLinkTrigger(handler);
		}

		//명령 하달 : 미싱 노트 오브젝트 처리 명령 하달
		public void relayD_MissingNote(int lineNum)
		{
			graphicCtrl.sendMissingNote(lineNum);
		}

		//명령 하달 : 바늘 회전 
		public void relayD_RotateNeedleObject(float rotDegree)
		{
			graphicCtrl.rotateNeedleObject(rotDegree);
		}
	}
}