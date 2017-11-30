using UnityEngine;
using System.Collections;


namespace InStageScene
{
	public class GameObjectsManager : MonoBehaviour
	{
		//클래스 레퍼런스s
		//상위
		[SerializeField] GraphicMananger graphicCtrl;
		//하위
		[SerializeField] ClockNeedle NeedleCtrl;
		[SerializeField] NoteDealer noteObjectPoolCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{

		}


		// Update is called once per frame
		void Update()
		{

		}


		//명령 하달 : 바늘 회전
		public void rotateNeedleObject(float rotDegree)
		{
			NeedleCtrl.rotateNeedle(rotDegree);
		}

		//명령 하달 : 초기 스테이지 준비!
		public void prepareStage()
		{

		}

		//노트풀에 미싱 노트 처리 명령
		public void sendMissingNote(int lineNum)
		{
			noteObjectPoolCtrl.returnMissingNote(lineNum);
		}

		public void sendStageStart()
		{
			noteObjectPoolCtrl.requestRefinedData();
		}
	}
}