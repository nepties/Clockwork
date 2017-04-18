using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class fileReader : MonoBehaviour
{
	//하위 리더 개체 제어 레퍼런스
	MetaDataReader MetaReaderCtrl;
	NoteDataReader NoteReaderCtrl;

	StreamReader reader;  //읽기스트림 객체

	//읽은 파일 데이터 저장 공간
	List<MusicMetaData> metaDataStorage;  //읽은 곡들 메타 데이터
	List<MusicNoteData> noteDataStorage;  //선택 곡의 노트 데이터

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		reader = new StreamReader("Tulip(Pro).txt");  //객체 생성 후 개방

		//하위 리더 객체 생성 부 (1회)
		MetaReaderCtrl = new MetaDataReader(reader);
		NoteReaderCtrl = new NoteDataReader(reader);

		//저장소 객체화
		metaDataStorage = new List<MusicMetaData>( );
		noteDataStorage = new List<MusicNoteData>( );

		//test
		forceReadMetaData( );
		forceReadNoteData( );
	}


	//메타 데이터 읽기 명령
	void forceReadMetaData()
	{
		metaDataStorage.Add( MetaReaderCtrl.readMetaData() );  //리스트에 하나 추가(임시)
	}


	//노트 데이터 읽기 명령
	void forceReadNoteData()
	{
		noteDataStorage.AddRange( NoteReaderCtrl.readAllnoteData() );  //리스트에 추가(임시)		
	}
}
