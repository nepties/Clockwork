using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kaibrary.MusicScrolls;



namespace MusicSelectMenuScene
{
	public partial class DataManager : MonoBehaviour
	{
		//ref````````````````````````
		//상위
		[SerializeField] GameManager coreCtrl;
		//하위
		[SerializeField] FileIndicator indicator;
		//DSU
		[SerializeField] DeepDataManager deepStorageCtrl;


		//수입 파일 데이터 저장 공간 (가공된 데이터)
		public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터


		// Use this for initialization
		void Start()
		{
			deepStorageCtrl = GameObject.Find("DeepStorageUnit").GetComponent<DeepDataManager>();  //link ref
		}


	}

	public partial class DataManager : MonoBehaviour
	{

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		public void exe()
		{

		}


		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//에셋내 모든 채보 리스트 로드
		public void relayD_loadListAll()
		{
			//Resources.LoadAll("Songs", );
		}

		//명시된 디렉토리 레벨에서 채보 리스트 로드
		public void relayD_loadListCurDir()
		{

		}
	}
}