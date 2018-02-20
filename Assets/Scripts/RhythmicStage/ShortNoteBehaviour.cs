using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RhythmicStage
{
	public class ShortNoteBehaviour : MonoBehaviour
	{
		float Speed { set; get; }  //��Ʈ ���� �ӵ� ���		

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-	

		// Update is called once per frame
		void Update()
		{
			//��Ʈ�� ���� �������� ��� ���� ��
			transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.Self);  //�̵�
		}

		//�ӵ� ���� 
		public void setSpeed(float configSpeed)
		{
			Speed = configSpeed;
		}
	}
}