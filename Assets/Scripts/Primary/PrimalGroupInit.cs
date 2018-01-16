using UnityEngine;

public class PrimalGroupInit : UnityEngine.MonoBehaviour
{

	// Use this for initialization
	void Awake()
	{
		//그룹 전체 파괴방지부여
		DontDestroyOnLoad(this);
		alsoApplyChild();
	}


	//그룹원 전부 파괴방지부여 메소드
	void alsoApplyChild()
	{		
		for (int i = 0; i < transform.childCount; i++)  //자식 오브젝트 수 만큼 반복
			DontDestroyOnLoad(transform.GetChild(i).gameObject);  //씬 전환 시 파괴방지부여
	}
}