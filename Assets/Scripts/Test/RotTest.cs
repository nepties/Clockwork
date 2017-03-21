using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class RotTest : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	//Image bgImg;
	//bool isForcedPressed;
	public string steerObjectName = "clockNeedle";
	[SerializeField]
	float rotationForce;  //가하는 회전 힘
	
	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	private void Start()
	{

	}

	public virtual void OnDrag(PointerEventData ped)
	{
		//Debug.Log("OnDrag   [J]");
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		//Debug.Log("Pressed   [J]");
		GameObject.Find(steerObjectName).GetComponent<Rotator>().rotateNeedle(rotationForce);
		//isForcedPressed = true;
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		//Debug.Log("Released   [J]");
		//isForcedPressed = false;
	}
}

