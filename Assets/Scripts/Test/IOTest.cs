using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class IOTest : MonoBehaviour
{
	StreamReader reader;  //읽기스트림 객체
	List<string> metaList;  //메타데이터 저장 리스트 객체
	MusicMetaData selectedMusic;    //보면 클래스
	byte curReadingPhase;  //읽기 모드
	int curReadingUnit;  //현재 읽는 시점의 유닛

	enum ReadingPhase : byte  //보면 읽기 모드
	{
		jointRead,
		bpmRead,
		unitRead
	}

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		reader = new StreamReader("Tulip(Pro).txt");  //객체 생성 후 개방
		metaList = new List<string>();  //리스트 객체 생성		
		selectedMusic = new MusicMetaData();  //보면 객체 생성
		readMetaData();  //메타 데이터 읽기
		readTranscriptionData(); //보면 읽기
		readNoteData(); //다음 유닛 읽기(한 줄)
		curReadingUnit = 1;
	}


	// Update is called once per frame
	void Update()
	{
	    
	}
	

	//메타데이터 부분 읽는 메소드
	void readMetaData()
	{
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

			//분석된 데이터를 리스트에 추가
			metaList.Add(values[1]);
		}

		//분석된 메타데이터 보면 클래스로 데이터 입력 부
		selectedMusic.importMetaData(metaList);			
		selectedMusic.printMetaData();  //데이터 출력 Test
	}


	//노트 배치 마디부분 읽기 메소드
	void readTranscriptionData()
	{
		//마디 인식 부
		if (reader.Peek() == '-')  //마디 구분자 일부 인 경우
		{
			//마디 인식 완료
			reader.ReadLine();  //마디 줄 넘김			
			curReadingPhase = (byte)ReadingPhase.bpmRead;  //해당 마디 변화 BPM 읽기 전환

			if (reader.Peek() >= 'A')  //숫자가 아닌 값이 있을 경우
			{
				//BPM 변속 마디 구간 감지 완료
				//데이터 추출 부
				//구분자 문자 설정 부
				char[] tempDelimiter = { '=' };  //'이퀄' 구분자를 구분
				string[] temp = (reader.ReadLine()).Split(tempDelimiter);  //'=' 문자를 기준으로 분석				

				//BPM 변속 적용 부
				//currentBpm = int.Parse(temp[1]);  //temp[1]이 파싱되어 나온 BPM 값
				//Debug.Log("BPM : " + bpm);
			}
		}
	}


	//실질적인 노트 배치 부분 읽는 메소드 (한 줄)
	void readNoteData()
	{ 		
		curReadingPhase = (byte)ReadingPhase.unitRead;  //노트 읽기 전환 
		//구분자 문자 설정 부
		char[] delimiter = { '|' };  //마디 구분자

		//읽기 부 (한 Unit 씩 == 한 줄)
		string[] determineBuffer = (reader.ReadLine()).Split(delimiter);  //마디 구분자를 모두 걸러냄
		// xxx xxx xxx xxx x 식으로 저장
		// [0] [1] [2] [3] [4]

		//노트 데이터 추출 부 (한 Unit 씩 == 한 줄)
		for(int i = 0; i < 4; i++)  //안쪽 노트 배치 데이터 4세트에 대해서
		{
			if (determineBuffer[i].CompareTo("000") > 0)  //한 셋트가 모두 000 값이 아니면 (노트 존재시)
			{
				//노트 단위로 데이터 추출
				for (int j = 0; j < 3; j++)
				{
					if(determineBuffer[i][j] > '0')
					{
						//노트 데이터 입력
						//(3 * i + j) 번째 큐에 입력

					}
				}				
			}			
		}

		//다음 유닛으로 설정 부
		curReadingUnit++;  //현재 시점 유닛수 증가


	}
}


//보면 메타 데이터 클래스
class MusicMetaData
{
	//채보 메타 데이터
	string title;  //음악제목
	string jacket;  //음악이미지 파일명
	string difficulty;  //보면 난이도
	string music;  //음악 파일명 
	int length;  //음악 길이(second)
	int bpm;  //Beat Per Minute
	int unit;  //보면데이터 유닛 수

	//노트 배치 데이터
	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	
	//메타 데이터 추가 메소드
	public void importMetaData(List<string> metaList)
	{
		title = metaList[0];
		jacket = metaList[1];
		difficulty = metaList[2];
		music = metaList[3];
		length = int.Parse(metaList[4]);
		bpm = int.Parse(metaList[5]);
		unit = int.Parse(metaList[6]);
	}

	//메타 데이터 리스트 출력 (한 줄로)
	public void printMetaData()
	{
		Debug.Log(title + " || " + jacket + " || " + difficulty + " || " + music + " || " + length + " || " + bpm + " || " + unit);
	}


	//보면 데이터 추가 메소드
	public void importNoteData()
	{

	}
}


//보면 데이터 큐 관리 클래스
public class MusicScroll
{
	Queue<ScrollNote> [] innerNoteQueue;  //안쪽 노트 배치 큐 배열
	Queue<ScrollNote> outerNoteQueue;  //바깥쪽 노트 배치 큐
	Queue beatTimer;  //마디 타이머 큐 : 변속 BPM 저장

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	public void readFirstNote()
	{
		//noteQueue.Peek().getLocatedUnit();
	}

	public void insertNoteArray()
	{

	}
}


//실질 보면 데이터 저장 구조체
public struct ScrollNote
{
	int locatedUnit;  //노트 위치 유닛
	int noteType;  //숏노트, 좌-하프노트, 우-하프노트

	public ScrollNote(int placedUnit, int defType)
	{
		locatedUnit = placedUnit;
		noteType = defType;
	}

	public int getLocatedUnit()
	{
		return locatedUnit;
	}
}

