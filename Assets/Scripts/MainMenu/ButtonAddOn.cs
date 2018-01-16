﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace MainManuScene
{
	public abstract class ButtonAddOn : UnityEngine.MonoBehaviour
	{
		//상위
		[SerializeField]
		protected ButtonPanel PanelCtrl;
		
		//눌리면 실행할 메서드
		public abstract void occurOrder();

		//panel ref link method
		public void linkRef2Panel(ButtonPanel upperRef)
		{
			PanelCtrl = upperRef;
		}
	}
}
