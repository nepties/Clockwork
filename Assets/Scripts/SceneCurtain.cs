using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneCurtain : MonoBehaviour
{
	[SerializeField]  Image imageCtrl;	
	
	// Use this for initialization
	void Awake()
	{
		//imageCtrl.color = Color.black;

		//image component On
		imageCtrl.enabled = true;  //cuz disable in initial
	}

	/*
	void OnEnable()
	{
		//image component On for Reloading
		imageCtrl.enabled = true;
	}*/

	//(Image alpha value) fade In Routine
	public IEnumerator fadeIn(float duration = 2f, float Interval = 0.05f)
	{
		Debug.Log("Curtain fade In");

		int fadingCount = (int)(1.0f / Interval);
		if (1.0f % Interval != 0)
			fadingCount += 1;

		WaitForSeconds delayRoutine = new WaitForSeconds(duration / fadingCount);

		for (int i = 0; i < fadingCount; i++)
		{
			Color curColor = imageCtrl.color;

			if (curColor.a == 0f)
				break;

			curColor.a -= Interval;
			curColor.a = Mathf.Clamp(curColor.a, 0, 1f);
			imageCtrl.color = curColor;
			yield return delayRoutine;
		}
		gameObject.SetActive(false);  //자동 비활성화
		yield return null;
	}

	//(Image alpha value) fade Out Routine
	public IEnumerator fadeOut(float duration = 2f, float Interval = 0.05f)
	{
		Debug.Log("Curtain fade Out");

		int fadingCount = (int)(1.0f / Interval);
		if (1.0f % Interval != 0)
			fadingCount += 1;

		WaitForSeconds delayRoutine = new WaitForSeconds(duration / fadingCount);

		for (int i = 0; i < fadingCount; i++)
		{
			Color curColor = imageCtrl.color;

			if (curColor.a == 1f)
				break;

			curColor.a += Interval;
			curColor.a = Mathf.Clamp(curColor.a, 0, 1f);
			imageCtrl.color = curColor;
			yield return delayRoutine;
		}
		yield return null;
	}
}