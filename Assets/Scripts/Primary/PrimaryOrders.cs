using UnityEngine;
using System.Collections;

public class PrimaryOrders : UnityEngine.MonoBehaviour
{
	[SerializeField] SceneNavigator navigatorCtrl;
	[SerializeField] SceneCurtain curtainCtrl;


	// Use this for initialization
	IEnumerator Start()
	{
		yield return StartCoroutine(navigatorCtrl.forceLoadNext_beta());
	}
}
