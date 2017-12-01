using UnityEngine;
using System.Collections;


namespace MainManuScene
{
	public class InputManager : MonoBehaviour
	{
		//상위
		[SerializeField] GameManager coreCtrl;

		// Use this for initialization
		void Awake()
		{

		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))  // W키 혹은 ↑ 스트록
				coreCtrl.forceChangeSelect(MenuKeyDirection.Up);

			if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))  // S키 혹은 ↓ 스트록
				coreCtrl.forceChangeSelect(MenuKeyDirection.Down);

			if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  // A키 혹은 ← 스트록
				coreCtrl.forceChangeSelect(MenuKeyDirection.Left);

			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))  // D키 혹은 → 스트록
				coreCtrl.forceChangeSelect(MenuKeyDirection.Right);

			if (Input.GetKeyDown(KeyCode.Return))  // 엔터키 스트록
				coreCtrl.forceEntering();
		}		
	}
}