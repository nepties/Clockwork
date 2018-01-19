using UnityEngine;
using System.Collections;

public class SceneNavigator : MonoBehaviour
{

	//ref
	[SerializeField] private SceneCurtain curtainCtrl;  //씬 커튼 ref

	WaitForSeconds loadReportDelay;  //로딩 진행 콘솔 출력 딜레이(caching)
	

	void Awake()
	{
		curtainCtrl = GameObject.Find("SceneCurtain").GetComponent<SceneCurtain>();  //link Curtain Object ref
		
		loadReportDelay = new WaitForSeconds(0.2f);  //delay set
	}
	
	//씬 로딩 코루틴 실행 메서드
	public void exeLoadNextScene_beta()
	{
		StartCoroutine(forceLoadNext_beta());
	}

	//curtain linking method
	public void exeInitialization()
	{
		curtainCtrl = GameObject.Find("SceneCurtain").GetComponent<SceneCurtain>();  //link ref
	}

	public IEnumerator forceloadNextScene(int sceneIndex)
	{		
		AsyncOperation async = Application.LoadLevelAsync(sceneIndex);
		async.allowSceneActivation = false;
		yield return async;
		Debug.Log("Loading complete");
		async.allowSceneActivation = true;
	}

	public IEnumerator forceloadNextScene(string sceneName)
	{
		AsyncOperation async = Application.LoadLevelAsync(sceneName);
		async.allowSceneActivation = false;
		yield return async;
		Debug.Log("Loading complete");
		async.allowSceneActivation = true;
	}

	public IEnumerator forceloadNextScene()
	{
		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel + 1);
		async.allowSceneActivation = false;
		yield return async;
		Debug.Log("Loading complete");
		async.allowSceneActivation = true;
	}

	public IEnumerator forceLoadNext_beta()
	{
		//인위적 딜레이 	
		//yield return new WaitForSeconds(1f);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel + 1);
		async.allowSceneActivation = false;
		Debug.Log("execute Loading Next scene!!");

		//Curtain activation method
		curtainCtrl.gameObject.SetActive(true);  //active Curtain
		yield return StartCoroutine(curtainCtrl.fadeOut());  //Run "fadeOut"

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone)
		{
			yield return loadReportDelay;
			Debug.Log("Loading... : " + async.progress * 100 + " %");

			if (async.progress >= 0.9f)
			{
				Debug.Log("Loading complete");
				async.allowSceneActivation = true;
			}				
		}

		yield return null;
	}


	//씬 로딩 후 호출될 메서드
	void OnLevelWasLoaded(int level)
	{
		exeInitialization();

		//장막 오브젝트 On
		//curtainCtrl.gameObject.SetActive(false);

		//장막 걷기 : 페이드 인
		StartCoroutine(curtainCtrl.fadeIn());
	}
}