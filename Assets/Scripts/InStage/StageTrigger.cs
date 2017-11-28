using UnityEngine;
using System.Collections;

public class StageTrigger : MonoBehaviour
{
	[SerializeField]	GameManager coreCtrl;
	[SerializeField]	DataManager dataCtrl;

	// Use this for initialization
	void Awake ()
	{		
		preprocess( );  //스테이지 로딩
	}

	//스테이지 준비직전 데이터 선-처리
	void preprocess( )
	{
		//곡 정보 하나 읽기 명령
		Debug.Log("Music selected, force stage Loading...");
		//곡 하나 읽어들이기
		//AddressBook.dataCtrl.forceLoadOneFile( );  //??? 지연 줘야 할듯
		StartCoroutine(loadForTest( ));
	}

	//곡 정보 읽기 완료 최종 확인
	public void FinalConfirmfileImportFinished( )
	{
		//GM에게 선곡 정보 전달
		coreCtrl.receiveMusicData( );
	}

	//명령 하달 : 
	IEnumerator loadForTest()
	{
		Debug.Log("waiting for fileReader Object making...");
		//yield return new WaitForSeconds(1f);
		yield return new WaitForFixedUpdate( );
		//곡 하나 읽어들이기
		dataCtrl.forceLoadOneFile( );
	}
}