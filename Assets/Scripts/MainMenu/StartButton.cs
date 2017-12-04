using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace MainManuScene
{
	public class StartButton : MonoBehaviour
	{

		[SerializeField]
		Button buttonCtrl;

		// Use this for initialization
		void Awake()
		{
			buttonCtrl.onClick.AddListener(exeStartingGame);
		}


		//누를 시 취할 메소드 : 선곡 씬으로 이동
		public void exeStartingGame()
		{

		}

		/*
		//누를 시 취할 메소드 : 선곡 씬으로 이동
		public void onClick()
		{
			Application.LoadLevel(2);
		}
		*/
	}
}