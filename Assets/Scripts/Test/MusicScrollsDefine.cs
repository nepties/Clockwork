using UnityEngine;
using System.Collections.Generic;

//노트, 메타데이터 정의 
namespace MusicScrolls
{
	//큐에 넣어질 노트 배치 요소
	public struct NoteJudgeCard
	{
		public int noteType { get; private set; }  //노트 타입
		public float time { get; private set; }  // 해당 NoteUnit의 재생 시간
		public int unitNum { get; private set; } //유닛 일련번호
	
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		public NoteJudgeCard(int noteType, float time, int unitNum)
		{
			this.noteType = noteType;
			this.time = time;
			this.unitNum = unitNum;
		}

		public void printContent()
		{
			Debug.Log(noteType + "::" + time + "__(" + unitNum + ")");
		}
	}

	//메타 데이터 클래스
	public class MusicMetaData
	{
		//채보 메타 데이터
		public string title { get; private set; }  //음악제목
		public string jacket { get; private set; }  //음악이미지 파일명(경로)
		public string difficulty { get; private set; }  //보면 난이도
		public string music { get; private set; }  //음악 파일명(경로)
		public int length { get; set; }  //음악 길이(second)
		public float bpm { get; set; }  //Beat Per Minute
		public int unit { get; set; }  //보면 유닛 수

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

	//노트 데이터 저장 구조체
	public struct MusicNoteData
	{
		int[] noteData;  // 노트 배치 정보. 크기는 13
		float time;  // 해당 NoteUnit의 재생 시간
		int unitTiming; //유닛 일련번호
		bool hasNoteData;  //해당 유닛에 노트 존재 여부

		//000 | 000 | 000 | 000 | 0  ---+ 처리 시점

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//구조체 생성자 & 입력
		public MusicNoteData(int[] unitNoteData, float unitTime, int treatUnit, bool hasNoteData)
		{
			noteData = unitNoteData;
			time = unitTime;
			unitTiming = treatUnit;
			this.hasNoteData = hasNoteData;
		}

		//현재시점 노트 정보 전달 메소드
		public int[] getLocatedArray()
		{
			return noteData;
		}

		//(Test) 해당 시점 노트 정보 전체 출력
		public void printNoteArray()
		{
			foreach(int i in noteData)
			{
				Debug.Log(i + " : " + unitTiming);
			}
		}

		//Get : 노트 여부
		public bool noteExistCheck()
		{
			return hasNoteData;
		}

		//Get : 노트가 위치하는 유닛번호
		public int getLineUnit()
		{
			return unitTiming;
		}

		//Get : 해당 유닛의 재생 시점(ms)
		public float getLineTiming()
		{
			return time;
		}
	}
}
