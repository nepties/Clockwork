using UnityEngine;
using System.Collections.Generic;


//노트, 메타데이터 정의 
namespace MusicScrolls
{
	/// <summary>
	///		노트판정 큐에 넣어질 노트 배치 요소
	/// </summary>
	public struct NoteJudgeCard
	{
		public int noteType { get;  set; }  //노트 타입
		public float time { get;  set; }  // 해당 NoteUnit의 재생 시간
		public int unitNum { get;  set; }  //유닛 일련번호
	
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		/// <summary>
		///		노트판정 카드 생성자
		/// </summary>
		/// <param name="noteType">어떤 노트 형태인지</param>
		/// <param name="time">처리 예정 시점</param>
		/// <param name="unitNum">처리 예정 시점 유닛</param>
		public NoteJudgeCard(int noteType, float time, int unitNum)
		{
			this.noteType = noteType;
			this.time = time;
			this.unitNum = unitNum;
		}

		/// <summary>
		///		해당 카드 내용 출력 for Test
		/// </summary>
		public void printContent()
		{
			Debug.Log("Type : " + noteType + " :: " + time + " (ms)__[ " + unitNum + " ]");
		}
	}

	/// <summary>
	///		메타 데이터 클래스
	/// </summary>
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
	
		/// <summary>
		///		메타 데이터 클래스 생성자
		/// </summary>
		/// <param name="metaList">관련 정보 문자열 리스트 레퍼런스</param>
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

		/// <summary>
		///		메타 데이터 리스트 출력 (한 줄로 Test)
		/// </summary>
		public void printMetaData()
		{
			Debug.Log(title + " || " + jacket + " || " + difficulty + " || " + music + " || " + length + " || " + bpm + " || " + unit);
		}
	}

	/// <summary>
	///		노트 데이터 저장 구조체
	/// </summary>
	public struct MusicNoteData
	{
		int[] noteData;  // 노트 배치 정보. 크기는 13
		float time;  // 해당 NoteUnit의 재생 시간
		int unitTiming; //유닛 일련번호
		bool hasNoteData;  //해당 유닛에 노트 존재 여부

		//000 | 000 | 000 | 000 | 0  ---+ 처리 시점

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		/// <summary>
		///		노트 데이터 저장 구조체 생성자
		/// </summary>
		/// <param name="unitNoteData">노트 정보 배열 레퍼런스</param>
		/// <param name="unitTime">노트 시점</param>
		/// <param name="treatUnit">노트 시점 유닛</param>
		/// <param name="hasNoteData">노트 데이터 존재 여부</param>
		public MusicNoteData(int[] unitNoteData, float unitTime, int treatUnit, bool hasNoteData)
		{
			noteData = unitNoteData;
			time = unitTime;
			unitTiming = treatUnit;
			this.hasNoteData = hasNoteData;
		}

		/// <summary>
		///		get : 현재시점 노트 정보 배열 반환 메소드
		/// </summary>
		/// <returns>
		///		노트 정보 배열 레퍼런스
		/// </returns>
		public int[] getLocatedArray()
		{
			return noteData;
		}

		/// <summary>
		///		get : 현재 시점 노트 데이터 출력
		/// </summary>
		public void printNoteArray()
		{
			foreach(int i in noteData)
			{
				Debug.Log(i + " : " + unitTiming);
			}
		}

		/// <summary>
		///		get : 현재 시점 노트 데이터 존재 여부
		/// </summary>
		/// <returns>
		///		적어도 노트 데이터 존재 : true
		///		존재 하지 않음 : false
		/// </returns>
		public bool noteExistCheck()
		{
			return hasNoteData;
		}

		/// <summary>
		///		get : 노트가 위치하는 유닛번호
		/// </summary>
		public int getLineUnit()
		{
			return unitTiming;
		}

		/// <summary>
		///		get : 해당 유닛의 재생 시점(ms)
		/// </summary>		
		public float getLineTiming()
		{
			return time;
		}

		public string getCurNoteDataAsString( )
		{
			string temp = time + " (ms) :: " ;
			for(int i = 0; i < 13; i++)
			{
				temp += noteData[i].ToString( );
			}
			temp += "(" + unitTiming + ")";
			return temp;
		}
	}
}
