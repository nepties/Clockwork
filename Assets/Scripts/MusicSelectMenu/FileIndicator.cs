using UnityEngine;
using System.IO;
using System.Collections;


namespace MusicSelectMenuScene
{
	public class FileIndicator : MonoBehaviour
	{

		string songFolderName = "songs";
		string startPath;

		// Use this for initialization
		void Awake()
		{			
			startPath = Directory.GetCurrentDirectory();
			songFolderName = Path.Combine(startPath, songFolderName);

			reportDataPath();

			Debug.Log(songFolderName);
			importFileList();
		}


		public void importFileList()
		{
			DirectoryInfo drinfo = new DirectoryInfo(songFolderName);
			foreach (FileInfo fiin in drinfo.GetFiles())
			{
				Debug.Log(fiin.FullName); //<< 가져오시면 되구요 Fullpath입니다.
				Debug.Log(fiin.Name); // fiin.Name 이게 파일이름일겁니다.				
			}
		}


		//for Test
		public void reportDataPath()
		{
			Debug.Log(Application.dataPath);
		}
	}
}