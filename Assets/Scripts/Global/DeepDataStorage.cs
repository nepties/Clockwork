using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockCore;



[CreateAssetMenu(fileName = "DeepDataStorage(Universal)", menuName = "Storages/DeepStorageUnit")]
public class DeepDataStorage : ScriptableObject
{
	#region configData
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	public Resolution resolution { get; set; }
	
	#endregion


	#region for RhythmicStage
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	public string SelectedMusicDir { get; set; }
	
	#endregion
}