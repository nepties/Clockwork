using UnityEngine;
using System.Collections;



namespace StartUp
{
	public class StartUpCore : CoreBase
	{
		[SerializeField] UIManager uiCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{

		}

		protected override void coreTrigger()
		{
			print("Scene Loaded");

			//▨ 로고 출력

			//
		}
	}
}
