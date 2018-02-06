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
		[SerializeField] NoteDropper dropperCtrl;
		[SerializeField] NoteRailPlatform platformCtrl;
		[SerializeField] BackLighter [] backlightCtrl;
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

		public void relayD_ShortInput(int InputChannel)
		{
			backlightCtrl[InputChannel].exeLightOn();
		}

		public void relayD_LongDeactivate(int InputChannel)
		{
			backlightCtrl[InputChannel].exeLightOff();
		}

		public void relayD_LinkTriggerNLoad(reflecMessagingHandler Handler)
		{
			dropperCtrl.exeLinkTriggerNLoad(Handler);
		}		

		public void relayD_treatMissingNote(int channel)
		{
			dropperCtrl.exeTreatMissingNote(channel);
		}

		public void relayD_ShortNoteJudge(int channel, noteJudgement judgement)
		{
			dropperCtrl.exeShortNoteJudge(channel);
		}
	}
}