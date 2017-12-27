using UnityEngine;
using System.IO;
using System.Collections.Generic;
using MusicScrolls;



namespace MusicSelectMenuScene
{
	public partial class FileReader : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] DataManager dataCtrl;
		//하위
		//분할 리더 개체 제어 레퍼런스
		MetaDataReader MetaReaderCtrl;  //메타 데이터 리더


		//
		StreamReader reader;  //읽기스트림 개체		

		//수입 파일 데이터 저장 공간 (가공된 데이터)
		public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터


		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//스트림리더 설정 부 (비유연형)
			//reader = new StreamReader("Follow Up.txt");  //객체 생성 후 개방		

			//하위 리더 객체 생성 부 (1회성(for Test)
			MetaReaderCtrl = new MetaDataReader();

			//저장소 객체화
			metaDataStorage = new List<MusicMetaData>();
		}
	}

	public partial class FileReader : MonoBehaviour
	{

	}
} 