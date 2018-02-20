using UnityEngine;
using System.Collections;
using ClockCore;
using UnityEngine.UI;
using Kaibrary.UIForge;



public class TopCanvasController : MonoBehaviour
{
	[SerializeField] GameObject curtainPrefeb;
	[SerializeField] SceneCurtain curtainCtrl;
	[SerializeField] GameObject curtainObject;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//커튼 생성
	void createCurtain()
	{
		//Initializing parts
		curtainObject = Instantiate(curtainPrefeb, this.transform);
		curtainCtrl = curtainObject.GetComponent<SceneCurtain>();
	}


	//커튼 걷기
	public void exeOpenCurtain()
	{



	}

	//커튼 치기
	public void exeDrawCurtain()
	{

	}
}
