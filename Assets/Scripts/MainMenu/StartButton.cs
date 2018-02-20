using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace MainMenuScene
{
	public class StartButton : ButtonAddOn
	{

		//눌리면 실행할 메서드 : 선곡 씬으로 이동 요청
		public override void occurOrder()
		{
			PanelCtrl.relayU_loadStageScene();
		}
	}
}