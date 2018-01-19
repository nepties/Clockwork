using UnityEngine;
using System.Collections;


namespace InStageScene
{
	public partial class UIManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField] GraphicMananger graphicCtrl;
		//하위	
		[SerializeField] VerdicText judgeText;


		// Use this for initialization
		void Awake()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		//판정 결과 통보
		public void popJudegText(int type)
		{
			judgeText.popText(type);
		}
	}

	//상하 명령 메서드 집합
	public partial class UIManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
		

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}