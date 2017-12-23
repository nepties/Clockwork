using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class GameManager : MonoBehaviour
	{
		//하위
		[SerializeField] DataManager dataCtrl;
		[SerializeField] InputManager inputCtrl;
		[SerializeField] ResourceManager resourceCtrl;

		// Use this for initialization
		void Start()
		{

		}

		public void forceChangeSelect(KeyInputDirection direc)
		{
			resourceCtrl.relayD_ChangeSelect(direc);
		}

		public void reportLoadStageScene()
		{

		}
	}
}