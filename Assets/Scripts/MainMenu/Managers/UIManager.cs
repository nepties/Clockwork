﻿using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class UIManager : MonoBehaviour
	{
		//상위
		[SerializeField] GraphicManager graphicCtrl;
		//하위
		[SerializeField] ButtonPanel buttonPanelCtrl;

		// Use this for initialization
		void Start()
		{

		}
		
		public void relayD_ChangeSelect(MenuKeyDirection direc)
		{
			buttonPanelCtrl.exeChangeSelection(direc);
		}
	}
}