using UnityEngine;
using System.Collections;


namespace MainMenuScene
{
	public class GraphicManager : MonoBehaviour
	{
		//상위
		[SerializeField] ResourceManager resourceCtrl;
		//하위
		[SerializeField] UIManager uiCtrl;

		// Use this for initialization
		void Start()
		{

		}		

		public void relayD_ChangeSelect(KeyInputDirection direc)
		{
			uiCtrl.relayD_ChangeSelect(direc);
		}

		public void relayU_loadStageScene()
		{
			resourceCtrl.relayU_loadStageScene();
		}
	}
}