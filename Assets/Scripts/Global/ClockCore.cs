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

	#region Single Active Scene List
	public enum SingleScene
	{
		StartUp,
		MainMenu,
		MusicSelect,
		OnStage,
		Result
	}
		
	#endregion


	#region State Definition

	//스테이지 씬 진행 상태
	public enum inRhythmicStageStates
	{
		firstEntry,  //최초 로딩
		enteringStage,  //스테이지 로딩
		stageOn,  //스테이지 화면
		result  //결과 화면
	}
	#endregion


	#region Definition about Notes
	//노트 판정
	public enum noteJudgement
	{
		perfect,
		nice,
		miss
	}

	//노트 타입
	public enum noteType
	{
		Blank,
		Short,
		RightQuarter,
		LeftQuarter,
		LongS,
		LongF
	}
	#endregion
}