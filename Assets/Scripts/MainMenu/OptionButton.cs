using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class OptionButton : ButtonAddOn
	{

		//눌리면 실행할 메서드 : 옵션 창 열기
		public override void occurOrder()
		{
			
			Debug.Log("config Window is OPened");
		}
	}
}