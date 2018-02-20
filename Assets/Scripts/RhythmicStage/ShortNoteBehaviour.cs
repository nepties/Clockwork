using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RhythmicStage
{
	public class ShortNoteBehaviour : MonoBehaviour
	{
		float Speed { set; get; }  //노트 진행 속도 배수		

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-	

		// Update is called once per frame
		void Update()
		{
			//노트가 설정 방향으로 계속 진행 부
			transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.Self);  //이동
		}

		//속도 설정 
		public void setSpeed(float configSpeed)
		{
			Speed = configSpeed;
		}
	}
}