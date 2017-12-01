using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


namespace MainManuScene
{
	public class ButtonPanel : MonoBehaviour
	{
		//상위
		[SerializeField] UIManager uiCtrl;
		//하위
		[SerializeField] Button [] buttonCtrl;
		[SerializeField] Button test;

		int buttonCount;  //버튼 갯수							
		[SerializeField]  int buttonActiveIndicator = 0;  //활성 버튼 인덱스 값

		// Use this for initialization
		void Start()
		{
			//버튼 갯수 파악 부
			buttonCount = transform.childCount;

			StartCoroutine("deferredDeliRef");

			Debug.Log("button Count in panel : " + buttonCount);
			

			//Debug.Log(buttonCtrl[0]);
		}

		//스타트 버튼 눌리면 호출될 메소드
		public void occurStart()
		{
			Debug.Log("Start button pressed!");
			
		}

		//옵션 버튼 눌리면 호출될 메소드
		public void occurOptionPop()
		{
			Debug.Log("Option button pressed!");

		}

		//나가기 버튼 눌리면 호출될 메소드
		public void occurExit()
		{
			Debug.Log("Exit button pressed!");

		}

		//키보드 입력에 따른 버튼 선택 순차 변경 메소드
		public void exeChangeSelection(MenuKeyDirection direction)
		{
			//버튼 하이라이트 변경(순환) 부
			//인덱스 순환
			buttonActiveIndicator = (buttonActiveIndicator + (int)direction + buttonCount) % buttonCount;

			//다음 알맞는 버튼 선택
			buttonCtrl[buttonActiveIndicator].Select();
		}

		public void setButtonRef()
		{
			buttonCtrl = gameObject.GetComponentsInChildren<Button>();
		}


		IEnumerator deferredDeliRef()
		{
			yield return new WaitForSeconds(1f);

			setButtonRef();

			test = buttonCtrl[0];

			//if null ref
			if (buttonCtrl[0] != null)
			{
				Debug.Log("has a ref");
			}

			//초기 선택 버튼 활성화(가장 위 버튼 활성화)
			buttonCtrl[0].Select();
		}
	}	
}