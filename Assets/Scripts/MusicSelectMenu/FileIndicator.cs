using UnityEngine;
using System.IO;
using System.Collections;


namespace MusicSelectMenuScene
{
	public class FileIndicator : MonoBehaviour
	{

		//ref
		//상위
		[SerializeField] DataManager dataCtrl;

		string songFolderPath = "Resources\\Songs";  //Resources\Songs	folder	

		// Use this for initialization
		void Awake()
		{
			string startPath = Application.dataPath;  // \Assets
			songFolderPath = Path.Combine(startPath, songFolderPath);
			

			print(songFolderPath);  // \ClockWork\songs
			
			//importFileList();
		}

		void Start()
		{
			searchResources();
		}

		public void importFileList()
		{
			DirectoryInfo drinfo = new DirectoryInfo(songFolderPath);
			DirectoryInfo [] songListDir = drinfo.GetDirectories();

			foreach (FileInfo fiin in drinfo.GetFiles())
			{
				Debug.Log(fiin.FullName); //Fullpath
				Debug.Log(fiin.Name); // fiin.Name 파일명		
			}
		}

		//for Test
		public void printDataPath()
		{
			print(Application.dataPath);
		}

		public void searchResources()
		{
			print("Textures " + Resources.FindObjectsOfTypeAll(typeof(Texture)).Length);
			print("AudioClips " + Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length);
		}
	}
}