using UnityEngine;
using System.Collections;

public class NoteObjectMethod : MonoBehaviour
{
	NoteDealer spawnPool;  //노트 배치 클래스 레퍼런스

	int birthNumber;  //몇 번째 대기큐에서 나온 오브젝트 인지 기억(출신 대기큐 번호)
	float maxSpeed;  //계산 속도 ???

	//시작벡터, 진행 벡터
    Vector2 firstVector;
    Vector2 secVector;

    //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

    // Use this for initialization
    void Start()
    {
		firstVector = transform.position;
		maxSpeed = 2.5f;
		spawnPool = GameObject.Find("NoteDealer").GetComponent<NoteDealer>();
    }

    // Update is called once per frame
    void Update()
    {
		//노트가 설정 방향으로 계속 진행 부
		transform.Translate(Vector3.up * maxSpeed * Time.deltaTime, Space.Self);  //이동

		//판정선까지 이동 여부 판단 부
		secVector = (Vector2)transform.position - firstVector;  //나아간 벡터 계산
		if (secVector.magnitude >= 5f)  //벡터 길이가 일정 이상이면
		{
			//비활성, 백 투더 풀
			this.gameObject.SetActive(false);  //비활성화
			transform.position = firstVector;  //초기 위치로 이동
			spawnPool.collectObject(this.gameObject, this.birthNumber);  //백 투더 풀	
		}
    }


	//속도 설정 메소드
	public void setSpeed(float speed)
	{
		this.maxSpeed = speed;
	}


	//출신 대기큐 번호 부여 메소드
	public void setQueueNumber(int number)
	{
		this.birthNumber = number;
	}


	//페이드 코루틴
	IEnumerator noteActive()
	{
		yield return new WaitForSeconds(0.4f);		
	}
}

