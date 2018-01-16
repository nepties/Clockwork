using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace InStageScene
{
	public class TestCode : UnityEngine.MonoBehaviour
	{
		[SerializeField] List<Transform> cupPosList;
		//인스펙터 창에서 리스트 크기 조절 및 수용값 넣기

		// Use this for initialization
		void Awake()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public List<Transform> getTwoPos()
		{
			Transform otherLoc;
			Transform anotherLoc;
			List<Transform> twoLoc = new List<Transform>(2);


			//첫 번째 선택 부
			int pickRandIndex = Random.Range(0, cupPosList.Count - 1);
			otherLoc = cupPosList[pickRandIndex];
			cupPosList.RemoveAt(pickRandIndex);

			//두 번쨰 선택 부
			pickRandIndex = Random.Range(0, cupPosList.Count - 1);
			anotherLoc = cupPosList[pickRandIndex];
			cupPosList.RemoveAt(pickRandIndex);

			//복사 테이블 내부 값 채우기
			twoLoc.Add(otherLoc);
			twoLoc.Add(anotherLoc);

			//원본 테이블 복구
			cupPosList.Add(otherLoc);
			cupPosList.Add(anotherLoc);

			return twoLoc;  //두 개 좌표 선택한 리스트 리턴
		}
	}
}