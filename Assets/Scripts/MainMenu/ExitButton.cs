using UnityEngine;
using System.Collections;


namespace MainMenuScene
{
	public class ExitButton : ButtonAddOn
	{

		//눌리면 실행할 메서드 : 앱 종료
		public override void occurOrder()
		{
			//나가기
			Application.Quit();
		}
	}
}