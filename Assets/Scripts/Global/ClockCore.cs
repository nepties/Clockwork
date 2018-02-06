using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;



namespace ClockCore
{
	//Delegates
	//Universal Delegate
	public delegate T genericDele<T, U>(params U[] link);

	//Modest Delegate
	public delegate void LightweightHandler();
	public delegate void messagingHandler(string message);
	public delegate void reflecMessagingHandler(string message, LightweightHandler reCall);

	//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


	#region State Definition

	//씬 전반 진행 상태
	public enum sceneState
	{
		primalLoading, //최초 로딩 씬
		mainMenu,  //엔트리 메뉴 씬
		collecting,  //재료 수집 리듬겜 씬
		encounter  //몬스터 전투 리듬겜 씬
	}

	//스테이지 씬 진행 상태
	public enum inRhythmicStageStates
	{
		firstEntry,  //최초 로딩
		enteringStage,  //스테이지 로딩
		stageOn,  //스테이지 화면
		result  //결과 화면
	}
	#endregion

	//노트 판정 열거자
	public enum noteJudgement
	{
		perfect,
		nice,
		miss
	}
}