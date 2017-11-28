﻿using UnityEngine;
using ClientStates;
using System.Collections;


public class GameManager : MonoBehaviour
{
	//클래스 레퍼런스s
	//하위 매니저
	[SerializeField] InputKeyManager inputCtrl;
	[SerializeField] DataManager dataCtrl;
	[SerializeField] ResourceManager resourceCtrl;
		
	//상태 계
	public inStageStates gameState { get; set; }  //현 상태	

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//상태 설정 부
		gameState = inStageStates.enteringStage;  //최초 상태 : 스테이지 로딩			
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
	 
	//바늘 회전 키입력 감지 & 명령 하달
	public void NeedleCtrlKeyInput(float rotDegree)
	{
		dataCtrl.rotateNeedleData(rotDegree);
		resourceCtrl.rotateNeedleObject(rotDegree);
	}

	//롱노트 활성화 키입력 감지 & 명령 하달
	public void longActiveKeyInput()
	{
		dataCtrl.LongNoteEngage();
	}

	//롱노트 '비'활성화 키입력 감지 & 명령 하달
	public void longDeactiveKeyInput()
	{
		dataCtrl.LongNoteRelease();
	}

	//선곡 정보 받은 후 동작
	public void receiveMusicData()
	{
		dataCtrl.prepareStage( );
	}

	//스테이지 준비 관련 데이터 처리 모두 완료(바로 스테이지 온)
	public void dataAllLoaded()
	{
		dataCtrl.stageStarting( );
		resourceCtrl.stageStarting( );
	}

	//미싱 노트 관련 처리
	public void receiveMissingNote(int lineNum)
	{
		resourceCtrl.sendMissingNote(lineNum);
	}
}