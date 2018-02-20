using UnityEngine;
using System.Collections;
using System.IO;
using ClockCore;
using System;



namespace RhythmicStage
{
	/// <summary>
	/// Data Importer & Exporter in RhythmicStage with LocalStorage, DSU
	/// </summary>
	public partial class DataPort : MonoBehaviour
	{
		//refs
		//직속상위
		[SerializeField] DataManager dataCtrl;
		//DeepStorageUnit
		[SerializeField] DeepStorageUnit deepDataCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;

		//# for Test
		string path = @"D:\Unity_Workspace\GroupWorkSpace\Clockwork\StreamingAssets\Songs\Follow Up\Follow Up.txt";

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		void checkingPath()
		{
			try
			{
				//로컬 저장소에 경로 저장
				storageCtrl.musicPath = path;
			}
			catch (Exception e)
			{
				print(e.Message);
				//리듬게임 실행 실패 처리 부
				//▨ 구현 예정
			}
		}
	}

	public partial class DataPort : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//선곡 정보 경로 수입 
		public void exeImportMusicPath(messagingHandler simpleHandler)
		{
			//경로 유효 확인 절차
			checkingPath();

			//로딩 계속
			simpleHandler("Importing a Music Path Completed");
		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	}
}