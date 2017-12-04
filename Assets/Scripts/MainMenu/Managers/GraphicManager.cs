using UnityEngine;
using System.Collections;


namespace MainManuScene
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

		public void relayD_ChangeSelect(MenuKeyDirection direc)
		{
			uiCtrl.relayD_ChangeSelect(direc);
		}

		public void relayD_Entering()
		{
			uiCtrl.relayD_Entering();
		}
	}
}