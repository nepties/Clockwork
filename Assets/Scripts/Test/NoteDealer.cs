using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteDealer : MonoBehaviour
{
	[SerializeField]  GameObject noteObject;  //숏 노트 오브젝트	
	[SerializeField]  int poolSize;  //풀링 오브젝트 생성량


	Queue<GameObject> [] poolQueue;  //비활성 오브젝트 대기큐
	float finalSpeed;  //임의 최종 속도

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//초기, 임의값 초기화 부
		poolSize = 20;  //생성량 초기설정값
		finalSpeed = 600f;  //임의 지정 최종 속도

		//대기큐 배열 생성 부
		poolQueue = new Queue<GameObject>[12]; 
		for(int i = 0; i < 12; i++)
		{
			poolQueue[i] = new Queue<GameObject>(poolSize);
		}
				
		//오브젝트 생성 부
		createNoteObject();
		//로드 완료
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	//풀링할 오브젝트 생성 메소드
	void createNoteObject()
	{
		//설정 수 만큼 생성 부
		for(int i = 0; i < 12; i++)
		{
			for(int j = 0; j < poolSize; j++)
			{
				GameObject creation = (GameObject)Instantiate(noteObject, this.transform.position, Quaternion.identity);  //생성
				creation.SetActive(false);  //비활성화
				creation.transform.Rotate(i * -30f * Vector3.forward);  //알맞게 회전
				creation.GetComponent<NoteObjectMethod>( ).setQueueNumber(i);  //출신 대기큐 번호 부여
				poolQueue[i].Enqueue(creation);  //오브젝트를 대기큐 입력
			}
		}
	}


	//스테이지 최초 로드 직후 노트 배치
	void dealInitialNote()
	{

	}


	//현재 읽기 시점(다음)에 노트 배치
	void dealNotes()
	{
		
	}


	//풀링 오브젝트 회수 메소드(백 투더 풀)
	public void collectObject(GameObject endedNote, int birthQueueNumber)
	{
		poolQueue[birthQueueNumber].Enqueue(endedNote);  //알맞는 큐에 다시 입력(오브젝트 회수)
	}
}
