using UnityEngine;
using System.Collections;


//필수 연관 컴포넌트 자동 포함
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class test : MonoBehaviour
{
    //컴포넌트 변수
    Animator charAni;
    AudioSource musicPlayer;
        public AudioClip[] auidioFile;
    Rigidbody2D charRigBody;
    BoxCollider2D hitBox;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
