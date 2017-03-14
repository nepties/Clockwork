using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class IOTest : MonoBehaviour
{
	StreamReader reader;  //읽기스트림 객체
	List<string> metaList;  //메타데이터 저장 리스트 객체
	Queue<T> musicalQuene;  //채보 저장 큐 객체

	//
	void Start()
	{
		this.reader = new StreamReader("Tulip(Pro).txt");  //객체 생성 후 개방
		this.metaList = new List<string>();  //리스트 객체 생성
		this.musicalQuene = new Queue<T>();  //큐 객체 생성
		readMetaData();
	}
	

	//
	void Update()
	{
	    
	}
	

	//메타데이터 부분 읽는 메소드
	void readMetaData()
	{
		//구분자 문자 설정 부
		char [] delimiter = {'='};

		//메타데이터가 있는 7줄 읽기 부
		for(int i = 0; i < 7; i++)
		{
			//읽기 부(한 줄 씩)			
			string[] values = (reader.ReadLine()).Split(delimiter);  //'=' 문자를 기준으로 분석
			
			//정보 유무 확인 부
			if (values.Length < 2)  //해당 입력 정보가 없을 경우
			{
				values[1] = "";  //'비어있음'을 입력
			}

			//분석된 데이터를 리스트에 추가
			metaList.Add(values[1]);
		}

		//Test_리스트 전체 출력
		foreach (string temp in metaList)
		{
			Debug.Log(temp);
		}
		//reader.Close();  //스트림 닫기
	}


	//채보 부분 읽는 메소드
	void readTranscriptionData()
	{
		//구분자 문자 설정 부
		string [] delimiter = { "--" };

		//채보데이터 읽기 부
		//읽기 부(한 줄 씩)
		string[] values = (reader.ReadLine()).Split(delimiter, StringSplitOptions.RemoveEmptyEntries);  //'--' 문자를 기준으로 분석

		Debug.Log(values[0]);

		//분석된 데이터를 리스트에 추가
		//metaList.Add(values[1]);

		//Debug.Log(metaList[0]);
		/*
		//Test_리스트 전체 출력
		foreach (string temp in metaList)
		{
			Debug.Log(temp);
		}
		*/
				
		reader.Close();  //스트림 닫기
	}
}