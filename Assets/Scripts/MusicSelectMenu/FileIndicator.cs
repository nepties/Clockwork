using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MusicSelectMenuScene
{
	public class FileIndicator : MonoBehaviour
	{
		//ref
		//상위
		[SerializeField] DataManager dataCtrl;

		string songFolderPath = "Resources\\Songs";  //Resources\Songs	folder	
		string songsDirPath = "Songs/";  //Resources\Songs	folder

		public enum SeekDirection { Forward, Backward };

		public AudioSource source;
		public List<AudioClip> clips = new List<AudioClip>();

		private int currentIndex = 0;

		private FileInfo[] soundFiles;
		private List<string> validExtensions = new List<string> { ".ogg", ".wav" }; // Don't forget the "." i.e. "ogg" won't work - cause Path.GetExtension(filePath) will return .ext, not just ext.
		private string absolutePath = "./"; // relative path to where the app is running - change this to "./music" in your case

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		void Start()
		{
			/*
			searchResources();

			//being able to test in unity
			if (Application.isEditor) absolutePath = "Assets/";

			if (source == null) source = gameObject.AddComponent<AudioSource>();

			ReloadSounds();*/
		}
		/*
		void OnGUI()
		{
			if (GUILayout.Button("Previous"))
			{
				Seek(SeekDirection.Backward);
				PlayCurrent();
			}
			if (GUILayout.Button("Play current"))
			{
				PlayCurrent();
			}
			if (GUILayout.Button("Next"))
			{
				Seek(SeekDirection.Forward);
				PlayCurrent();
			}
			if (GUILayout.Button("Reload"))
			{
				ReloadSounds();
			}
		}

		//cyclic Seeking Method
		void Seek(SeekDirection d)
		{
			if (d == SeekDirection.Forward)
				currentIndex = (currentIndex + 1) % clips.Count;
			else
			{
				currentIndex--;
				if (currentIndex < 0) currentIndex = clips.Count - 1;
			}
		}

		void PlayCurrent()
		{
			source.clip = clips[currentIndex];
			source.Play();
		}

		void ReloadSounds()
		{
			clips.Clear();
			// get all valid files
			var info = new DirectoryInfo(absolutePath);
			soundFiles = info.GetFiles()
				.Where(f => IsValidFileType(f.Name))
				.ToArray();

			// and load them
			foreach (var s in soundFiles)
				StartCoroutine(LoadFile(s.FullName));
		}

		bool IsValidFileType(string fileName)
		{
			return validExtensions.Contains(Path.GetExtension(fileName));
			// Alternatively, you could go fileName.SubString(fileName.LastIndexOf('.') + 1); that way you don't need the '.' when you add your extensions
		}

		IEnumerator LoadFile(string path)
		{
			WWW www = new WWW("file://" + path);
			print("loading " + path);

			AudioClip clip = www.GetAudioClip(false);
			while (clip.loadState != AudioDataLoadState.Loaded)
				yield return www;

			print("done loading");
			clip.name = Path.GetFileName(path);
			clips.Add(clip);
		}
		*/
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			string startPath = Application.dataPath;  // \Assets
			songFolderPath = Path.Combine(startPath, songFolderPath);
			

			print(songFolderPath);  // \ClockWork\songs
			
			//importFileList();
		}

		//파일 리스트 수입 메서드
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

		//리소스 전체 검색
		public void searchResources()
		{
			print("Textures " + Resources.FindObjectsOfTypeAll(typeof(Texture)).Length);
			print("AudioClips " + Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length);
		}
	}
}