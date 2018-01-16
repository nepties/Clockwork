using UnityEngine;
using System.Collections;
using Kaibrary.CallbackModule;


namespace InStageScene
{
	public partial class SoundManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField] ResourceManager resourceCtrl;
		//하위

		//for Test
		public AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
		[SerializeField] AudioSource musicPlayer;  //오디오 플레이어

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		// Use this for initialization
		void Awake()
		{
			
		}

		//클립 선택 재생
		void playMusic(int clipNum)
		{
			musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
			musicPlayer.Play();  //재생
		}

		//트리거 연결
		public void reportLinkTrigger(reflecMessagingDele Handler)
		{
			Handler("SoundMaster : get a linker!", exeShowTime);
		}

		//Sound fade In Routine
		public IEnumerator fadeIn(float duration = 2f, float Interval = 0.05f)
		{
			Debug.Log("Curtain fade Out");

			int fadingCount = (int)(1.0f / Interval);
			if (1.0f % Interval != 0)
				fadingCount += 1;

			WaitForSeconds delayRoutine = new WaitForSeconds(duration / fadingCount);


			//Fader
			for (int i = 0; i < fadingCount; i++)
			{
				//checking already Done it
				if (musicPlayer.volume == 1f)
					break;

				musicPlayer.volume += Interval;
				musicPlayer.volume = Mathf.Clamp(musicPlayer.volume, 0, 1f);

				//Delaying
				yield return delayRoutine;
			}			
			yield break;
		}

		//Sound fade Out Routine
		public IEnumerator fadeOut(float duration = 2f, float Interval = 0.05f)
		{
			Debug.Log("Curtain fade Out");

			int fadingCount = (int)(1.0f / Interval);
			if (1.0f % Interval != 0)
				fadingCount += 1;			

			WaitForSeconds delayRoutine = new WaitForSeconds(duration / fadingCount);


			//Fader
			for (int i = 0; i < fadingCount; i++)
			{
				//checking already Done it
				if (musicPlayer.volume == 0)
					break;

				musicPlayer.volume -= Interval;
				musicPlayer.volume = Mathf.Clamp(musicPlayer.volume, 0, 1f);

				//Delaying
				yield return delayRoutine;
			}
			yield break;			
		}
	}


	//상하 명령 메서드 집합
	public partial class SoundManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//Execute a stage music
		public void exeShowTime()
		{
			playMusic(1);
		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}