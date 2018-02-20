using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class GameObjectManager : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] RhythmicCore coreCtrl;
		//하위
		[SerializeField] NoteDealer dealerCtrl;
		[SerializeField] NoteRailPlatform platformCtrl;
		[SerializeField] ClockNeedle NeedleCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	}

	//상하 명령 메서드 집합
	public partial class GameObjectManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		public void relayD_LinkTriggerNLoad(reflecMessagingHandler Handler)
		{
			dealerCtrl.exeLinkTriggerNLoad(Handler);
		}		

		public void relayD_treatMissingNote(int channel)
		{
			dealerCtrl.exeTreatMissingNote(channel);
		}

		public void relayD_ShortNoteJudge(int channel, noteJudgement judgement)
		{
			dealerCtrl.exeShortNoteJudge(channel);
		}

		//명령 하달 : 바늘 회전
		public void relayD_rotateNeedleObject(float rotDegree)
		{
			NeedleCtrl.rotateNeedle(rotDegree);
		}
	}
}