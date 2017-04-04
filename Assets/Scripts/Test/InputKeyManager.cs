using UnityEngine;
using System.Collections;

public class InputKeyManager : MonoBehaviour
{
	public string steerObjectName = "clockNeedle";  // clockNeedle 오브젝트 이름
	[SerializeField]
	GameObject steerObject;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for initialization
	void Start()
	{
		steerObject = GameObject.Find(steerObjectName);  //조정 오브젝트 이름으로 찾기
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown("space"))
		if (Input.GetKeyDown(KeyCode.F))  // F키 스트록 시, 왼쪽 한 칸
			steerObject.GetComponent<Rotator>().rotateNeedle(-1f);

		if (Input.GetKeyDown(KeyCode.D))  // D키 스트록 시, 왼쪽 세 칸
			steerObject.GetComponent<Rotator>().rotateNeedle(-3f);

		if (Input.GetKeyDown(KeyCode.J))  // J키 스트록 시, 오른쪽 한 칸
			steerObject.GetComponent<Rotator>().rotateNeedle(1f);

		if (Input.GetKeyDown(KeyCode.K))  // K키 스트록 시, 오른쪽 한 칸
			steerObject.GetComponent<Rotator>().rotateNeedle(3f);
	}
}