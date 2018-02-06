using UnityEngine;
using ClockCore;
using System.Collections;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class SoundManager : MonoBehaviour
	{
		//refs
		//상위
		
		
		//for Test
		[SerializeField] AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
		[SerializeField] AudioSource musicPlayer;  //오디오 플레이어

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		//클립 선택 재생
		void playMusic(int clipNum = 0)
		{
			musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
			musicPlayer.time = 0.2f;
			musicPlayer.Play();  //재생
		}

		//스톱워치 시간 출력
		void OnGUI()
		{
			GUI.Label(new Rect(300, 120, 200, 20), "AudioElapsed : " + musicPlayer.time.ToString());
		}

		/*
		//Sound fade In Routine
		public IEnumerator volumeFadeIn(AudioSource musicPlayer, float duration = 2f, float Interval = 0.05f)
		{
			Debug.Log("Sound fade Out");

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
		public IEnumerator volumeFadeOut(AudioSource musicPlayer, float duration = 2f, float Interval = 0.05f)
		{
			Debug.Log("Sound fade Out");

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
		*/
	}


	//상하 명령 메서드 집합
	public partial class SoundManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//Execute a stage music
		public void exeShowTime()
		{
			playMusic();
		}

		//트리거 연결
		public void exeLinkTrigger(reflecMessagingHandler Handler)
		{
			Handler("SoundMaster : get a linker!", exeShowTime);
		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	}
}