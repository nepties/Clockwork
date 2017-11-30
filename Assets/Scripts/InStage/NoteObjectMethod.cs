using UnityEngine;


namespace InStageScene
{
	public class NoteObjectMethod : MonoBehaviour
	{
		// [SerializeField] NoteDealer spawnPool;  //노트 배치 클래스 레퍼런스
		float Speed { set; get; }  //노트 진행 속도 배수


		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Start()
		{
			//초기화 부
			Speed = DataManager.instance.railSpeed;  //속도값 초기화		
		}

		// Update is called once per frame
		void Update()
		{
			//노트가 설정 방향으로 계속 진행 부
			transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);  //이동
		}


		//속도 설정 메소드
		public void setSpeed(float configSpeed)
		{
			Speed = configSpeed;
		}
	}
}