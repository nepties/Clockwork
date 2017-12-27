using UnityEngine;
using System.Collections.Generic;
using System.IO;
using MusicScrolls;



public class NoteDataReader
{
	StreamReader reader;  //읽기스트림 객체	
	byte curReadingState;  //읽기 모드

	int curReadingUnit;  //현재 읽는 시점의 유닛
	List<MusicNoteData> noteDataStorage;  //임시 노트 저장공간
	float barBeatPerUnit;  //해당 마디의 유닛 수
	float currentBpm;  //현재 읽는 시점 BPM
	float noteReadDelay;//bpm에 따른 읽기 지연 시간(ms)

	enum ReadingState : byte  //보면 읽기 모드
	{
		Idle,  //idle
		barRead,  //마디 읽기
		bpmRead,  //BPM 읽기
		unitRead  //유닛 읽기(노트)
	}

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//생성자
	public NoteDataReader(StreamReader readIndicator)
	{
		//제어 개체 레퍼런스 받아오기
		//fileDataCtrl = GameObject.Find("fileReader").GetComponent<fileReader>();

		//초기화 부
		curReadingState = (byte)ReadingState.Idle;  //유휴 상태
		curReadingUnit = 0;  //현재읽는 유닛 초기화 수치
		barBeatPerUnit = 64;  //기본 4/4

		reader = readIndicator;  //리더 스트림 받기
		
		noteDataStorage = new List<MusicNoteData>();  //저장소 객체화	
	}

	//노트 데이터 끝까지 읽어들이기
	public List<MusicNoteData> readAllnoteData()
	{
		noteDataStorage.Clear( );  //임시 저장공간 청소


		//메타데이터 읽기 부
		readCertainMetaData( );

		//끝까지 읽기
		while(!(reader.EndOfStream))
		{
			//마디 읽기 부
			readTranscriptionData(); //마디 첫 줄 읽기
			//노트 읽기 부
			for(int i = 0; i < barBeatPerUnit; i++)
			noteDataStorage.Add( readNoteData() ); //다음 유닛 읽기(한 줄)		
		}

		//스트림 닫기
		reader.Close( );

		//담은 노트 데이터 송출
		return noteDataStorage;
	}

	//'마디' 부분 읽기 메소드
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

				//BPM 변속 적용 부(미연결) : BPM  수치 업데이트(이슈 함수 호출 필요)
				currentBpm = float.Parse(temp[1]);  //temp[1]이 파싱되어 나온 BPM 값
				updateReadingDelay( );  //BPM에 따른 읽기 지연 시간 업데이트
				Debug.Log("BPM : " + currentBpm);
			}
		}
	}

	//'노트배치' 부분 읽는 메소드 (한 줄)
	MusicNoteData readNoteData()
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

		//다음 유닛으로 설정 부
		++curReadingUnit;  //현재 시점 유닛수 증가

		//노트데이터 송출(한 줄)
		if(notebufferEmpty < 5)  //한 줄에 적어도 한 개 노트 존재 시
		{
			//Debug.Log("ms : " + (curReadingUnit - 1) * noteReadDelay + " 노트입력 감지!  [ " + (curReadingUnit - 1) + " ]" );
			return new MusicNoteData(noteDataBuffer, (curReadingUnit - 1) * noteReadDelay, curReadingUnit - 1, true);
		}  //하나도 없다면
		else  return new MusicNoteData(noteDataBuffer, (curReadingUnit - 1) * noteReadDelay, curReadingUnit - 1, false);
	}

	//메타 데이터 부분 건너뛰기 메소드
	void skipMetaDataPart()
	{
		//메타 데이터 줄 수 만큼 읽고 넘기기
		for(int i = 0; i < 7; i++)
			reader.ReadLine();
	}

	//노트 읽기 지연시간 계산 메소드
	void updateReadingDelay()
	{
		noteReadDelay = 3750f / currentBpm;
	}

	//메타데이터 부분 특정 정보 읽기 메소드(for Test)
	void readCertainMetaData()
	{		
		//구분자 문자 설정 부
		char [] delimiter = {'='};  //'이퀄' 구분자를 구분

		//필요없는 메타데이터 5줄 읽기 부
		for (int i = 0; i < 5; i++)
		{
			reader.ReadLine( );  //한 줄씩 건너 뛰기
		}

		//읽기 부(한 줄 씩)			
		string[] values = (reader.ReadLine()).Split(delimiter);  //'=' 문자를 기준으로 분석
		//BPM 정보 추출
		this.currentBpm = float.Parse(values[1]);
		Debug.Log("BPM ex : " + currentBpm);
		updateReadingDelay( );  //BPM에 따른 읽기 지연시간 초기 계산

		//필요없는 메타데이터 마지막 3 줄 스킵 부
		reader.ReadLine( ); reader.ReadLine(); reader.ReadLine();
	}
}