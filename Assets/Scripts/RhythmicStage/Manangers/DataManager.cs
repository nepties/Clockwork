using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;
using System.IO;



namespace RhythmicStage
{
	//���� ���� ��� ����
	public partial class DataManager : MonoBehaviour
	{
		//refs
		//����
		[SerializeField] RhythmicCore coreCtrl;  //RhythmicCore
		//����
		[SerializeField] DataPort portCtrl;
		fileReader parserCtrl;		
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
	}

	//���� ��� �޼��� ����
	public partial class DataManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//���� �ε� ���
		public void exeLoadMusicScroll(messagingHandler simpleHandler)
		{
			
			//��Ʈ�� ���� ��
			parserCtrl = new fileReader(new StreamReader(storageCtrl.musicPath));

			//���� ��Ÿ������ �ε� ��
			storageCtrl.metaDataStorage = parserCtrl.readMetaData();			

			//���� ��Ʈ������ �ε� ��
			storageCtrl.noteDataStorage = parserCtrl.readNoteData();

			//��Ʈ������ ���� ��
			storageCtrl.judgeScroll = parserCtrl.ExtractJudgeScroll();

			//���� ������ ���� ���� ��
			storageCtrl.noteScroll = parserCtrl.copyRefinedQueue();
			


			//������ ��
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