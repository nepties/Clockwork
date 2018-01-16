using UnityEngine;
using System.Collections;


namespace InStageScene
{
	public class ClockNeedle : UnityEngine.MonoBehaviour
	{				
		float currentDegree;  //현재 회전 각도	
		float targetDegree;  //회전 목표 각도

		[SerializeField]
		[Range((0), (100))]
		float rotationSmooth;  //회전 감도

		[SerializeField] bool isRotating;  //현재 오브젝트 회전 관련 명령 수행 여부

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Start()
		{
			transform.rotation = Quaternion.identity;  //12시 정시에 초기화
			targetDegree = transform.rotation.z;  //각도 0
			rotationSmooth = 30f;  //초기 감도
		}

		// Update is called once per frame
		void Update()
		{		
			//회전 목표 각도와 현재 각도가 일치하지 않는다면
			if (Quaternion.Euler(0, 0, targetDegree) != transform.rotation)
			{
				isRotating = true;  //회전중
				//구형 보간 : 부드러운 회전
				Quaternion target = Quaternion.Euler(0, 0, targetDegree);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSmooth);
				//Debug.Log("force Rotate");
			}
			else
			{
				isRotating = false;  //회전멈춤
			}	
		}

		//바늘 회전 메소드
		public void rotateNeedle(float rotateDegree)  // rotateDegree : 1, -1, 3, -3 칸 회전 값
		{  		
			targetDegree = targetDegree + rotateDegree * -30f;  //목표 회전 각도 계산
			//transform.Rotate(Vector3.right * rotateDegree);
		}
	}
}