using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MetaDataReader
{
	StreamReader reader;  //읽기스트림 객체	

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//생성자
	public MetaDataReader(StreamReader readIndicator)
	{
		reader = readIndicator;		
	}

	//메타데이터 저장 객체 생성 메소드
	public MusicMetaData readMetaData()
	{
		List<string> metaList = new List<string>();  //메타데이터 저장 리스트 객체		
		
		//구분자 문자 설정 부
		char [] delimiter = {'='};  //'이퀄' 구분자를 구분

		//메타데이터가 있는 7줄 읽기 부
		for (int i = 0; i < 7; i++)
		{
			//읽기 부(한 줄 씩)			
			string[] values = (reader.ReadLine()).Split(delimiter);  //'=' 문자를 기준으로 분석

			//정보 유무 확인 부
			if (values.Length < 2)  //해당 입력 정보가 없을 경우
			{
				values[1] = null;  //'비어있음'을 입력
			}

			//분석된 (메타)데이터를 리스트에 추가
			metaList.Add(values[1]);
		}

			/*
			//분석된 메타데이터 보면 클래스로 데이터 입력 부
			selectedMusic.importMetaData(metaList);			
			selectedMusic.printMetaData();  //데이터 출력 Test
			*/

		//마무리 부
		//읽기스트림 닫기
		//reader.Close( );
		
		//읽은 메타 데이터 객체 레퍼런스 반환
		return new MusicMetaData(metaList);
	}
}


//메타 데이터 클래스
public class MusicMetaData
{
	//채보 메타 데이터
	string title;  //음악제목
	string jacket;  //음악이미지 파일명
	string difficulty;  //보면 난이도
	string music;  //음악 파일명 
	int length;  //음악 길이(second)
	float bpm;  //Beat Per Minute
	int unit;  //보면 유닛 수

	//노트 배치 데이터
	//MusicNoteData noteStruct;  //노트 데이터 관리 클래스 레퍼런스
	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	
	//메타 데이터 추가 생성자
	public MusicMetaData(List<string> metaList)
	{
		title = metaList[0];
		jacket = metaList[1];
		difficulty = metaList[2];
		music = metaList[3];
		length = int.Parse(metaList[4]);
		bpm = float.Parse(metaList[5]);
		unit = int.Parse(metaList[6]);
	}

	//메타 데이터 리스트 출력 (한 줄로 Test)
	public void printMetaData()
	{
		Debug.Log(title + " || " + jacket + " || " + difficulty + " || " + music + " || " + length + " || " + bpm + " || " + unit);
	}
}