using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	[SerializeField]	ResourceManager resourceCtrl;
	//하위

	//for Test
	public AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
    [SerializeField]	AudioSource musicPlayer;  //오디오 플레이어

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		musicPlayer = GetComponent<AudioSource>();  //컴포넌트의 음악 플레이어 연결
	}

	//BGM 선택 재생
    void playMusic (int clipNum)
    {
        musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
        musicPlayer.Play();  //재생
    }

	public void musicOn()
	{
		playMusic(1);
	}
}
