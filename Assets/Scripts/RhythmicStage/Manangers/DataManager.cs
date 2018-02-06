using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;
using System.IO;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class DataManager : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] RhythmicCore coreCtrl;  //RhythmicCore
		//하위
		[SerializeField] DataPort portCtrl;
		[SerializeField] fileReader parserCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;


		//sigleTon parts
		public static DataManager instance;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;
		}

		// Use this for initialization after all Object are made
		void Start()
		{

		}
	}

	//상하 명령 메서드 집합
	public partial class DataManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//선곡 로딩 명령
		public void exeLoadMusicScroll(messagingHandler simpleHandler)
		{
			//스트림 생성 부
			parserCtrl = new ScrollParser(new StreamReader(storageCtrl.musicPath));

			//선곡 메타데이터 로드 부
			storageCtrl.metaDataStorage = parserCtrl.readMetaData();			

			//선곡 노트데이터 로드 부
			storageCtrl.noteDataStorage = parserCtrl.readAllnoteData();

			//노트데이터 가공 부
			storageCtrl.judgeScroll = parserCtrl.ExtractJudgeScroll();

			//가공 데이터 깊은 복사 부
			storageCtrl.noteScroll = parserCtrl.copyRefinedQueue(storageCtrl.judgeScroll);

			//마무리 부
			//Call Back
			simpleHandler("file loading Completed");
		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		public void relayD_importMusic(messagingHandler simpleHandler)
		{			
			portCtrl.exeImportMusicPath(simpleHandler);
		}
	}
}