using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


namespace InStageScene
{
	public class VerdicText : MonoBehaviour
	{
		public Sprite[] texts;  //판정 결과 이미지 저장 배열
		float fadingDuration;  //페이드 지속 시간
		public Image ctrlImg;  //이미지 스크립트 형태 컴포넌트 제어


		// Use this for initialization
		void Awake()
		{
			fadingDuration = 1.5f;  //지속 시간 초기값 설정	
			ctrlImg.color = Color.clear;  //색상 투명화
		}

		//출력 (업데이트)
		public void popText(int type)
		{  // 0 : 퍼팩트 순
			ctrlImg.color = Color.white;  //색상 알파값 활성화(흰색)	
		}

		//페이드 아웃 메소드
		public void fadeOut()
		{
			Mathf.MoveTowards(1, 0, Time.deltaTime * (1 / fadingDuration));
		}
	}
}