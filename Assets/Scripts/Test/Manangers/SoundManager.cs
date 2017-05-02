using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	ResourceManager resourceCtrl;
	//하위

	//for Test
	public AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
    AudioSource musicPlayer;  //오디오 플레이어

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//제어 개체 레퍼런스 받아오기
		resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//BGM 선택 재생
    public void playMusic (int clipNum)
    {
        musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
        musicPlayer.Play();  //재생
    }
}
