using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class fileReader : MonoBehaviour
{
	//클래스 레퍼런스s
	//상위 개체 제어 레퍼런스
	DataManager dataCtrl;
	//하위 리더 개체 제어 레퍼런스
	MetaDataReader MetaReaderCtrl;
	NoteDataReader NoteReaderCtrl;

	StreamReader reader;  //읽기스트림 개체
	StreamReader NoteReader;  //읽기스트림 개체

	//수입 파일 데이터 저장 공간
	public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터
	public List<MusicNoteData> noteDataStorage { get; set; }  //선택 곡의 노트 데이터

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//제어 개체 레퍼런스 받아오기
		dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>();

		//스트림리더 설정 부
		reader = new StreamReader("Tulip(Pro).txt");  //객체 생성 후 개방		

		//하위 리더 객체 생성 부 (1회성(for Test)
		MetaReaderCtrl = new MetaDataReader(reader);
		NoteReaderCtrl = new NoteDataReader(reader);

		//저장소 객체화
		metaDataStorage = new List<MusicMetaData>( );
		noteDataStorage = new List<MusicNoteData>( );
	}

		
	//선곡 데이터 읽어들이기(for Test)
	public void readOneFullFile()
	{
		//한 곡 풀세트(?) 읽기			
		forceReadMetaData( );
		forceReadNoteData( );

		//파일 데이터 로드 완료
		metaDataStorage[0].printMetaData( );
		//로드 완료 상태 보고 to DataManager
		dataCtrl.reportLoadfinished( );
	}

	//메타 데이터 읽기 명령
	void forceReadMetaData()
	{
		metaDataStorage.Add( MetaReaderCtrl.readMetaData() );  //리스트에 하나 추가(임시)
	}

	//노트 데이터 읽기 명령
	void forceReadNoteData( )
	{
		noteDataStorage.AddRange(NoteReaderCtrl.readAllnoteData( ));  //리스트에 추가(임시)		
	}
}
