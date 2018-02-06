using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ImporterTest : MonoBehaviour
{
	[SerializeField] AudioClip [] clips;

	[SerializeField] List<string> pathList = new List<string>();

	string initalPath = "Songs\\";

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	
	// Use this for initialization
	void Start()
	{
		//Application.dataPath;
		//D: /Unity_Workspace/GroupWorkSpace/Clockwork/Assets
		//Application.streamingAssetsPath;
		//D: /Unity_Workspace/GroupWorkSpace/Clockwork/Assets/StreamingAssets

		loadClip();
	}

	void loadClip()
	{
		//디렉토리 경로 설정 부
		DirectoryInfo dirSearch = new DirectoryInfo(Application.dataPath + "/Resources/Songs");
		DirectoryInfo[] dirList = dirSearch.GetDirectories();

		//음악 제목 추출 부
		for (int i = 0; i < dirList.Length; i++)
		{
			//print(dirList[i].Name);
			string musics = dirList[i].Name + "\\" + dirList[i].Name;
			pathList.Add(Path.Combine(initalPath, musics));
		}

		//클립 추출 부
		AudioClip[] clips = new AudioClip[pathList.Count];
		for (int i = 0; i < pathList.Count; i++)
		{			
			clips[i] = Resources.Load<AudioClip>(pathList[i]);			
		}
		this.clips = clips;
	}
}
