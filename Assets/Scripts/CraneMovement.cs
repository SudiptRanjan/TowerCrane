using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
	//float  yMinValue=-0.7480196f, yManValue= -0.1820065f;
	float yMinValue = -35f, yManValue = -7f;
	public Rigidbody rb;
	[SerializeField] private float speed;

	

	private void OnEnable()
	{
		Events.onPlayerMoves += Move;
		//Events.onPlayerRotate += Rotate;
	}

	private void OnDisable()
	{
		Events.onPlayerMoves -= Move;
		//Events.onPlayerRotate -= Rotate;

	}

	private void Move( float yDirection)
	{
        //yDirection = Math.Clamp()
        //transform.localPosition = new Vector3(0, Mathf.Clamp(transform.localPosition.y, yMinValue, yManValue), 1);
        transform.localPosition = new Vector3(0,  2.49f, Mathf.Clamp(transform.localPosition.z, yMinValue, yManValue));

		//transform.Translate(0, Mathf.Clamp(transform.localPosition.y, yMinValue, yManValue), 1);
		transform.Translate(Vector3.forward * yDirection * Time.deltaTime * speed);

		//print(yDirection);
	}


}
//VR Drum
//-Positioning of drum sticks
//- change the effectof base drum

//VR
//-Attachement of the object to hoock
//-Clamping the lengt of rope 
