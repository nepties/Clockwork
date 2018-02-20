using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using ClockCore;



/// <summary>
/// Main part of GM
/// </summary>
public partial class GameManager : MonoBehaviour
{
	//refs
	//SceneNavigator
	[SerializeField]
	SceneNavigator sceneController;

	//씬에 따른 상태
	SingleScene sceneState;

	//씬 트리거 명령 셋 딕셔너리
	Dictionary<SingleScene, LightweightHandler> triggerSet;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization before All Object are loaded
	void Awake()
	{
		//Primal Initializer
		triggerSet = new Dictionary<SingleScene, LightweightHandler>(SceneManager.sceneCountInBuildSettings);
		print("Total Build Scene COunt : " + SceneManager.sceneCountInBuildSettings);
		setupTriggerSet();

		DontDestroyOnLoad(this);
	}


	//딕셔너리식 명령셋 설정
	void setupTriggerSet()
	{
		triggerSet.Add(SingleScene.StartUp, trigger_StartUp);
		// 실행은 이렇게 triggerSet[SingleScene.StartUp]();		
		triggerSet.Add(SingleScene.MainMenu, trigger_MainMenu);
		triggerSet.Add(SingleScene.MusicSelect, trigger_MusicSelector);
		triggerSet.Add(SingleScene.OnStage, trigger_Stage);
		//triggerSet.Add(SingleScene.Result, trigger_Result);
	}


	//다음 씬 준비 명령
	void forceLoadNextScene()
	{
		
	}


}