using UnityEngine;
using System.Collections;


namespace MainMenuScene
{
	public class ResourceManager : MonoBehaviour
	{
		//상위
		[SerializeField] MainMenuCore coreCtrl;
		
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