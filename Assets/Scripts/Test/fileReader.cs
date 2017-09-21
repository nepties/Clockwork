using UnityEngine;
using System.IO;
using System.Collections.Generic;
using MusicScrolls;

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

	//수입 파일 데이터 저장 공간 (가공된 데이터)
	public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터
	public List<MusicNoteData> noteDataStorage { get; set; }  //선택 곡의 노트 데이터

	//재가공 노트 데이터 저장 큐
	Queue<NoteJudgeCard> [] judgeScroll = new Queue<NoteJudgeCard>[13];

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start ()
	{
		//제어 개체 레퍼런스 받아오기
		dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>();

		//스트림리더 설정 부 (비유연형)
		reader = new StreamReader("Follow Up.txt");  //객체 생성 후 개방		

		//하위 리더 객체 생성 부 (1회성(for Test)
		MetaReaderCtrl = new MetaDataReader(reader);
		NoteReaderCtrl = new NoteDataReader(reader);

		//저장소 객체화
		metaDataStorage = new List<MusicMetaData>( );
		noteDataStorage = new List<MusicNoteData>( );

		//큐 배열 생성 부
		for(int i = 0; i < 13; i++)  //13개 큐
		{
			judgeScroll[i] = new Queue<NoteJudgeCard>();
		}
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
		dataCtrl.reportReadfinished( );
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

	//노트 데이터 재가공
	public void extractJudgeScroll( )
	{
		//노트 데이터 순차 접근
		foreach(MusicNoteData indic in noteDataStorage)
		{
			//노트데이터 있는 unit 찾을 시
			if(indic.noteExistCheck() == true)
			{
				//해당 유닛의 노트데이터 배열에 순차 접근
				for(int i = 0; i < 13; i++)
				{
					int note = indic.getLocatedArray( )[i];
					if(note >= 1)  //노트 데이터만 검출
					{
						judgeScroll[i].Enqueue(new NoteJudgeCard(note, indic.getLineTiming(), indic.getLineUnit()));
						//Debug.Log(indic.getLineTiming( ));
						judgeScroll[i].Peek( ).printContent( );
					}
				}
			}
		}

		//마무리 보고
		dataCtrl.sendRefineData(judgeScroll);	
	}
}
