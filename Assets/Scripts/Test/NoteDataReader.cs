using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class NoteDataReader : MonoBehaviour
{
	StreamReader reader;  //읽기스트림 객체	
	byte curReadingState;  //읽기 모드
	int curReadingUnit;  //현재 읽는 시점의 유닛

	enum ReadingState : byte  //보면 읽기 모드
	{
		barRead,  //마디 읽기
		bpmRead,  //BPM 읽기
		unitRead  //유닛 읽기(노트)
	}

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		//reader = new StreamReader("Tulip(Pro).txt");  //객체 생성 후 개방		
		//readTranscriptionData(); //보면 읽기
		//readNoteData(); //다음 유닛 읽기(한 줄)
		curReadingUnit = 1;  //현재읽는 유닛 초기화 수치
	}	

	//노트 배치 마디부분 읽기 메소드
	void readTranscriptionData()
	{
		//마디 인식 부
		if (reader.Peek() == '-')  //마디 구분자 일부 인 경우
		{
			//마디 인식 완료
			reader.ReadLine();  //마디 줄 넘김			
			curReadingState = (byte)ReadingState.bpmRead;  //해당 마디 변화 BPM 읽기 전환

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
		curReadingState = (byte)ReadingState.unitRead;  //노트 읽기 전환
		int[] noteDataBuffer = new int[13];  //추출 노트데이터 저장 버퍼
		byte notebufferEmpty = 0;  //노트데이터 저장 버퍼 내부 공백 여부 누적 판단

		//구분자 문자 설정 부
		char[] delimiter = { '|' };  //마디 구분자

		//읽기 부 (한 Unit 씩 == 한 줄)
		string[] determineBuffer = (reader.ReadLine()).Split(delimiter);  //마디 구분자를 모두 걸러냄
		// xxx xxx xxx xxx  x 식으로 저장
		// [0] [1] [2] [3] [4]

		//노트 데이터 추출 부 (한 Unit 씩 == 한 줄) : 숏노트 추출 부
		for(int i = 0; i < 4; i++)  //안쪽 노트 배치 데이터 4세트에 대해서(숏노트 데이터 만)
		{
			if (determineBuffer[i].CompareTo("000") > 0)  //한 세트가 모두 000 값이 아니면 (숏노트 존재시)
			{
				//노트 단위로 데이터 추출
				for (int j = 0; j < 3; j++)
				{
					//(숏)노트 데이터 입력
					//(3 * i + j) 번째 [0 ~ 11]
					noteDataBuffer[3 * i + j] = int.Parse(determineBuffer[i][j].ToString());
				}
			}
			else  //한 세트가 모두 000 (숏노트 없음)
			{
				//(숏)노트 데이터 '공백' 입력
				for(int k = 0; k < 3; k++)
				{
					noteDataBuffer[3 * i + k] = 0;
				}
				notebufferEmpty++;  //공백 정보 누적
			}
		}
		//(한 Unit 씩 == 한 줄) : 롱노트 추출 부
		if(determineBuffer[4].CompareTo("0") == 0)  //롱노트 없을 시
		{
				noteDataBuffer[12] = 0;
			notebufferEmpty++;
		}
		else  //롱노트 존재 시
		{
			noteDataBuffer[12] = int.Parse(determineBuffer[4]);			
		}
		//노트데이터 한 줄 추출 완료


		//노트데이터 송출
		if(notebufferEmpty == 5)  //한 줄 공백 시
		{
			//송출 안함
		}
		else  //한 줄에 노트 데이터 존재
		{
			//송출
		}


			/*
			//ForTest
			string bufferTest = null;
			for(int i = 0; i < 13; i++)
			{
				bufferTest = string.Concat(bufferTest, noteDataBuffer[i].ToString());
			}

			if (notebufferEmpty == 5)  Debug.Log("한줄 공백 감지");

			Debug.Log(bufferTest + " :: " + notebufferEmpty);
			*/


		//다음 유닛으로 설정 부
		curReadingUnit++;  //현재 시점 유닛수 증가
	}
}


//노트 데이터 저장 구조체
public struct MusicNoteData
{
	int[] noteData;  // 노트 배치 정보. 크기는 13
	float time;  // 해당 NoteUnit의 재생 시간
	int unitTiming; //처리 유닛 시점

	//000 | 000 | 000 | 000 | 0  ---+ 처리 시점

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//구조체 생성자 & 입력
	public MusicNoteData(int[] unitNoteData, float unitTime, int treatUnit)
	{
        noteData = unitNoteData;
        time = unitTime;
		unitTiming = treatUnit;
	}

	//현재시점 노트 정보 전달 메소드
	public int[] getLocatedUnit()
	{
		return this.noteData;
	}
}