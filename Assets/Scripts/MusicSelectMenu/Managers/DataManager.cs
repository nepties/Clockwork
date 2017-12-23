using UnityEngine;
using System.Collections;


namespace MusicSelectMenuScene
{
	public class DataManager : MonoBehaviour
	{
		//ref
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] FileIndicator indicator;

		// Use this for initialization
		void Start()
		{

		}

		//에셋내 모든 채보 리스트 로드
		void relayD_loadListAll()
		{
			//Resources.LoadAll("Songs", );
		}

		//명시된 디렉토리 레벨에서 채보 리스트 로드
		void relayD_loadListCurDir()
		{

		}
	}
}