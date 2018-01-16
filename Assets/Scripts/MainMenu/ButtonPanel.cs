using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


namespace MainManuScene
{
	public class ButtonPanel : UnityEngine.MonoBehaviour
	{
		//상위
		[SerializeField] UIManager uiCtrl;
		//하위
		[SerializeField] Button [] buttonCtrl;


		[SerializeField] EventSystem eventSysCtrl;  //이벤트 시스템 오브젝트 레퍼런스
		[SerializeField] Selectable curSelected;  //현재 선택된 버튼
		int buttonCount;  //버튼 갯수
		int buttonActiveIndicator = 0;  //활성 버튼 인덱스 값


		// Use this for initialization
		void Start()
		{
			//버튼 갯수 파악 부
			buttonCount = transform.childCount;
			
			//패널에 존재하는 모든 버튼 연결
			buttonCtrl = gameObject.GetComponentsInChildren<Button>();
			
			//첫 번째 버튼 설정 & 이벤트 시스템에게도 전달
			curSelected = buttonCtrl[0];
			eventSysCtrl.firstSelectedGameObject = buttonCtrl[0].gameObject;

			//Test
			Debug.Log("button Count in panel : " + buttonCount);
		}		

		//키보드 입력에 따른 버튼 선택 순차 변경 메소드
		public void exeChangeSelection(KeyInputDirection direction)
		{
			/*
			//다음 위 선택
			if (direction == KeyInputDirection.Up)
			{
				curSelected = curSelected.FindSelectableOnUp();
				curSelected.Select();
			}
			
			//다음 아래 선택
			else if (direction == KeyInputDirection.Down)
			{
				curSelected = curSelected.FindSelectableOnDown();
				curSelected.Select();
			}
				
			//다음 왼쪽 선택
			else if (direction == KeyInputDirection.Left)
			{
				curSelected = curSelected.FindSelectableOnLeft();
				curSelected.Select();
			}
			
			//다음 오른쪽 선택
			else if (direction == KeyInputDirection.Right)
			{
				curSelected = curSelected.FindSelectableOnRight();
				curSelected.Select();
			}*/
		}

		public void relayU_loadStageScene()
		{
			uiCtrl.relayU_loadStageScene();
		}
	}	
}