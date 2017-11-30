using UnityEngine;
using System.Collections.Generic;
using System.IO;
using MusicScrolls;


namespace InStageScene
{
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
			char[] delimiter = { '=' };  //'이퀄' 구분자를 구분

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

			//마무리 부
			//읽기스트림 되감기(For Test)
			reader.BaseStream.Seek(0, SeekOrigin.Begin);
			reader.DiscardBufferedData();

			//읽은 메타 데이터 객체 레퍼런스 반환
			return new MusicMetaData(metaList);
		}
	}
}