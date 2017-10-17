using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteDealer : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위
	GameObjectsManager gameObjectCtrl;

	[SerializeField]  GameObject noteObject;  //숏 노트 오브젝트	
	int poolSize;  //오브젝트 풀 최대 수용량


	Queue<GameObject> [] poolQueue;  //비활성 오브젝트 대기큐
	Queue<GameObject> [] activePoolQueue;  //활성 오브젝트 관리큐
	float finalSpeed;  //임의 최종 속도

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Awake ()
	{
		//제어 개체 레퍼런스 받아오기
		gameObjectCtrl = GameObject.Find("GameObjects").GetComponent<GameObjectsManager>();
		
		//초기, 임의값 초기화 부
		poolSize = 20;  //생성량 초기설정값
		finalSpeed = 600f;  //임의 지정 최종 속도

		//비활성 오브젝트 대기큐 배열 생성 부
		poolQueue = new Queue<GameObject>[12]; 
		for(int i = 0; i < 12; i++)  //12개 대기열
		{
			poolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
		}

		//활성 오브젝트 관리큐 배열 생성 부
		activePoolQueue = new Queue<GameObject>[12];
		for(int i = 0; i < 12; i++)  //12개 대기열
		{
			activePoolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
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
				GameObject creation = (GameObject)Instantiate(noteObject, this.transform.position, Quaternion.identity);  //오브젝트 생성
				creation.transform.Rotate(i * -30f * Vector3.forward);  //알맞게 회전
				creation.SetActive(false);  //비활성화				
				//creation.GetComponent<NoteObjectMethod>( ).setQueueNumber(i);  //출신 대기큐 번호 부여
				poolQueue[i].Enqueue(creation);  //오브젝트를 대기큐 입력
			}
		}
	}

	//스테이지 최초 로드 직후 노트 배치
	void dealInitialNote()
	{

	}

	//알맞는 시점(다음)에 노트 배치
	void forceDealNotes()
	{
		
	}
	
	//풀링 오브젝트 회수 메소드(백 투더 풀)
	public void collectObject(GameObject endedNote, int birthQueueNumber)
	{
		poolQueue[birthQueueNumber].Enqueue(endedNote);  //알맞는 큐에 다시 입력(오브젝트 회수)
	}
}