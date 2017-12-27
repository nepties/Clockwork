using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MusicScrolls;



public class DeepDataManager : MonoBehaviour
{
	//선곡 데이터 저장소
	public MusicMetaData metaDataStorage { get; set; }  //읽은 곡들 메타 데이터
	public List<MusicNoteData> noteDataStorage { get; set; }  //선택 곡의 노트 데이터

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Awake()
	{

	}

	//선곡 데이터 수입 메서드
	public void exeimportSelectionMusicData(MusicMetaData metaData, List<MusicNoteData> noteData)
	{
		//link refs
		metaDataStorage = metaData;
		noteDataStorage = noteData;
	}
}