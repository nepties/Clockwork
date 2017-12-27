using UnityEngine;
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



		//명령 하달 : 스테이지 시작
		public void stageStarting()
		{
			graphicCtrl.sendStageStart();
			soundCtrl.exePlayStageMusic();
		}

		//미싱 노트 오브젝트 처리 명령 하달
		public void sendMissingNote(int lineNum)
		{
			graphicCtrl.sendMissingNote(lineNum);
		}
	}


	//상하 명령 메서드 집합
	public partial class ResourceManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


		//relay parts : relayU_- or relayD_- or force
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//명령 하달 : 바늘 회전 
		public void forceRotateNeedleObject(float rotDegree)
		{
			graphicCtrl.rotateNeedleObject(rotDegree);
		}
		
		//명령 하달 : 극초기 상태 스테이지 준비
		public void forcePrepareStage()
		{
			graphicCtrl.prepareStage();
		}
	}
}