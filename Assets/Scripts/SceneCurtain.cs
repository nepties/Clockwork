using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kaibrary.UIForge;
using ClockCore;



public class SceneCurtain : MonoBehaviour
{
	[SerializeField]  Image imageCtrl;

	event LightweightHandler fadingCompleted;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	public void exeFadeOutCurtain()
	{
		StartCoroutine(FadeOutCurtain());
	}

	public void exeFadeinCurtain()
	{
		StartCoroutine(FadeInCurtain());
	}

	IEnumerator FadeOutCurtain()
	{
		yield return StartCoroutine(UIForge.alphaFadeOut(imageCtrl));

		if (fadingCompleted != null)
			fadingCompleted();

		yield return null;
	}

	IEnumerator FadeInCurtain()
	{
		yield return StartCoroutine(UIForge.alphaFadeIn(imageCtrl));

		if (fadingCompleted != null)
			fadingCompleted();

		yield return null;
	}
}