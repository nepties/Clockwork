using System.Collections;
using UnityEngine;
using UnityEngine.UI;



namespace InStageScene
{
	public class VerdicText : MonoBehaviour
	{
		public Sprite[] texts;  //판정 결과 이미지 저장 배열
		float fadingDuration;  //페이드 지속 시간
		public Image imageCtrl;  //이미지 스크립트 형태 컴포넌트 제어


		// Use this for initialization
		void Awake()
		{
			fadingDuration = 1.5f;  //지속 시간 초기값 설정	
			imageCtrl.color = Color.clear;  //색상 투명화\			
		}

		/// <summary>
		///		판정 텍스트 출현 메서드
		/// </summary>
		/// <param name="type">
		///		0 : 퍼팩트(최상급 판정) ~ Max : 가장 최하급 판정 순
		/// </param>
		public void popText(int type)
		{
			imageCtrl.color = Color.white;  //색상 알파값 활성화(흰색)	
		}

		//페이드 아웃 메소드
		//(Image alpha value) fade Out Routine
		public IEnumerator fadeOut(Image targetImg, float duration = 2f, float Interval = 0.05f)
		{
			Debug.Log("Curtain fade Out");

			int fadingCount = (int)(1.0f / Interval);
			if (1.0f % Interval != 0)
				fadingCount += 1;

			WaitForSeconds delayRoutine = new WaitForSeconds(duration / fadingCount);

			for (int i = 0; i < fadingCount; i++)
			{
				Color curColor = targetImg.color;

				if (curColor.a == 1f)
					break;

				curColor.a += Interval;
				curColor.a = Mathf.Clamp(curColor.a, 0, 1f);
				targetImg.color = curColor;
				yield return delayRoutine;
			}
			yield return null;
		}
	}
}