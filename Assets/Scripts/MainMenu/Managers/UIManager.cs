using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class UIManager : UnityEngine.MonoBehaviour
	{
		//상위
		[SerializeField] GraphicManager graphicCtrl;
		//하위
		[SerializeField] ButtonPanel buttonPanelCtrl;

		// Use this for initialization
		void Start()
		{

		}
		
		public void relayD_ChangeSelect(KeyInputDirection direc)
		{
			buttonPanelCtrl.exeChangeSelection(direc);
		}

		public void relayU_loadStageScene()
		{
			graphicCtrl.relayU_loadStageScene();
		}
	}
}