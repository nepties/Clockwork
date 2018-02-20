using UnityEngine;
using System.Collections.Generic;
using ClockCore;



[CreateAssetMenu(fileName = "DeepStorageUnit(Global)", menuName = "Storages/DeepStorageUnit(Global)")]
public class DeepStorageUnit : ScriptableObject
{
	#region configData
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	public Resolution resolution { get; set; }

	#endregion


	#region for SelectScreen
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-	
	public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터

	#endregion


	#region for RhythmicStage
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	public string SelectedMusicDir { get; set; }  //선곡 경로
	public MusicMetaData selectedMusicMetaData { get; set; }  //특정 선곡의 메타 데이터
	public List<MusicNoteData> noteDataStorage { get; set; }  //특정 선곡의 노트 데이터

	#endregion





	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-	
}