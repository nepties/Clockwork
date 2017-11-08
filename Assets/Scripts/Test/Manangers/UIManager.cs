using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	//하위 요소
	[SerializeField]	VerdicText judgeText;
	
	
	// Use this for initialization
	void Awake ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void popJudegText(int type)
	{
		judgeText.popText(type);
	}
}
