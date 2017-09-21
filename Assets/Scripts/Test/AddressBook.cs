using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace ReferenceSetting
{
	public static class AddressBook
	{
		//클래스 레퍼런스s
		//최상위
		public static GameManager coreCtrl { get; private set; }  //GM
		//1티어 매니저
		public static InputKeyManager inputCtrl;  //인터페이스 관련 매니저
		public static DataManager dataCtrl { get; private set; }  //게임 내부데이터 관련 매니저
		public static ResourceManager resourceCtrl { get; private set; }  //게임 리소스 관련 매니저
		//2티어 매니저
		public static GraphicMananger graphicCtrl { get; private set; }  //게임 그래픽 관련 매니저
		//데이터 매니저 직속
		public static NoteReferee refereeCtrl { get; private set; }  //노트 판정확인 클래스
		public static fileReader fileDataCtrl { get; private set; }  //파일 정보 수입 클래스
		//게임오브젝트 매니저 하위 게임 오브젝트
		public static ClockNeedle NeedleCtrl { get; private set; }  //시계 바늘 오브젝트 클래스
		public static NoteDealer noteObjectPoolCtrl { get; private set; }  //노트 배분기 오브젝트 클래스
		
		//로딩완료시간 측정
		public static Stopwatch stopwatch = new Stopwatch( );

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		public static void linkReference ()
		{
			stopwatch.Start( );
			
			//제어 개체 레퍼런스 받아오기
			coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>( );
			inputCtrl = GameObject.Find("KeyInputMananger").GetComponent<InputKeyManager>( );
			dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>( );
			resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>( );
			refereeCtrl = GameObject.Find("NoteReferee").GetComponent<NoteReferee>( );
			fileDataCtrl = GameObject.Find("fileReader").GetComponent<fileReader>( );
			graphicCtrl = GameObject.Find("GraphicManager").GetComponent<GraphicMananger>( );
			NeedleCtrl = GameObject.Find("clockNeedle").GetComponent<ClockNeedle>( );
			noteObjectPoolCtrl = GameObject.Find("NoteDealer").GetComponent<NoteDealer>( );

			stopwatch.Stop( );
			Debug.Log( "linking Ref loading Time : " + stopwatch.ElapsedTicks + " (tick)");
		}
	}
}


/*
using UnityEngine;
using System.Collections;

namespace StageSetting
{
	public class StageTrigger : MonoBehaviour
	{
		//클래스 레퍼런스s
		//최상위
		public GameManager coreCtrl { get; private set; }  //GM
		//1티어 매니저
		public InputKeyManager inputCtrl;  //인터페이스 관련 매니저
		public DataManager dataCtrl { get; private set; }  //게임 내부데이터 관련 매니저
		public ResourceManager resourceCtrl { get; private set; }  //게임 리소스 관련 매니저
		//2티어 매니저
		public GraphicMananger graphicCtrl { get; private set; }  //게임 그래픽 관련 매니저
		//데이터 매니저 직속
		public NoteReferee refereeCtrl { get; private set; }  //노트 판정확인 클래스
		public fileReader fileDataCtrl { get; private set; }  //파일 정보 수입 클래스
		//게임오브젝트 매니저 하위 게임 오브젝트
		public ClockNeedle NeedleCtrl { get; private set; }  //시계 바늘 오브젝트 클래스
		public NoteDealer noteObjectPoolCtrl { get; private set; }  //노트 배분기 오브젝트 클래스

		// Use this for initialization
		void Start ()
		{
			//제어 개체 레퍼런스 받아오기
			coreCtrl = GameObject.Find("GameMainCore").GetComponent<GameManager>( );
			inputCtrl = GameObject.Find("KeyInputMananger").GetComponent<InputKeyManager>( );
			dataCtrl = GameObject.Find("DataManager").GetComponent<DataManager>( );
			resourceCtrl = GameObject.Find("ResourceManager").GetComponent<ResourceManager>( );
			refereeCtrl = GameObject.Find("NoteReferee").GetComponent<NoteReferee>( );
			fileDataCtrl = GameObject.Find("fileReader").GetComponent<fileReader>( );
			graphicCtrl = GameObject.Find("GraphicManager").GetComponent<GraphicMananger>();
			NeedleCtrl = GameObject.Find("clockNeedle").GetComponent<ClockNeedle>();
			noteObjectPoolCtrl = GameObject.Find("NoteDealer").GetComponent<NoteDealer>();
		}

		// Update is called once per frame
		
		void Update ()
		{
		
		}
		
	}
}
*/