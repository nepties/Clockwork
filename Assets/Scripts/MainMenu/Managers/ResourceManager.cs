using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class ResourceManager : MonoBehaviour
	{
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GraphicManager graphicCtrl;

		// Use this for initialization	

		public void relayD_ChangeSelect(MenuKeyDirection direc)
		{
			graphicCtrl.relayD_ChangeSelect(direc);
		}

		public void relayD_Entering()
		{
			graphicCtrl.relayD_Entering();
		}
	}
}