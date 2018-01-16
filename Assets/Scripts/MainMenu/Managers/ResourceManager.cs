using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class ResourceManager : UnityEngine.MonoBehaviour
	{
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GraphicManager graphicCtrl;

		// Use this for initialization	

		public void relayD_ChangeSelect(KeyInputDirection direc)
		{
			graphicCtrl.relayD_ChangeSelect(direc);
		}

		public void relayU_loadStageScene()
		{
			coreCtrl.reportLoadStageScene();
		}
	}
}