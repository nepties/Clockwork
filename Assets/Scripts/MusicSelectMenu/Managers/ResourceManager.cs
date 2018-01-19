using UnityEngine;
using System.Collections;


namespace MusicSelectMenuScene
{
	public class ResourceManager : MonoBehaviour
	{
		//ref
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GraphicManager graphicCtrl;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}