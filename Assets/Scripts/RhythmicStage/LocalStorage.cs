using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;



namespace RhythmicStage
{
	[CreateAssetMenu(fileName = "LocalStorage(RhythmicStage)", menuName = "Storages/LocalStorage(RhythmicStage)")]
	public class LocalStorage : ScriptableObject
	{
		public string musicPath;

		public Queue<NoteJudgeCard>[] judgeScroll { get; set; }  //판정을 위한 노트 큐
		public Queue<NoteJudgeCard>[] noteScroll { get; set; }  //노트출력을 위한 노트 큐

		public MusicMetaData metaDataStorage { get; set; }  //선곡 메타 데이터
		public List<MusicNoteData> noteDataStorage { get; set; }  //선택 곡의 노트 데이터

		//리듬 옵션 관련
		const float SPEEDCONST = 1f;  //배속 상수
		public readonly int curChannel = 3;  // x Key

		public float curBpm { get; set; }  //현재 재생 곡 BPM		
		[SerializeField] [Range((0), (10))] float speedFactor;  //배속 배수
		public float railSpeed { get; set; }  //레일 스피드 : 최종 노트 속도
	}
}