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
	float clampMovement = 0;
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
        //if(yDirection== 1 || yDirection > 0)
        //{
        //	clampMovement += Time.deltaTime * speed;
        //}
        //else if(yDirection == -1 || yDirection < 0)
        //      {
        //	clampMovement -= Time.deltaTime * speed;
        //}

        if (yDirection == 1 || yDirection > 0)
        {
            if (yDirection > 0 && yDirection < 0.3)
            {
                clampMovement += Time.deltaTime * speed * 0.3f;
                //print("Gear 1");
            }
            else if (yDirection > 0.3 && yDirection < 0.7)
            {
                clampMovement += Time.deltaTime * speed * 0.6f;
                //print("Gear 2");
            }
            else if (yDirection > 0.7 && yDirection < 1)
            {
                clampMovement += Time.deltaTime * speed;
                //print("Gear 3");
            }
        }
        else if (yDirection == -1 || yDirection < 0)
        {
            if (yDirection < 0 && yDirection > -0.3)
            {
                clampMovement -= Time.deltaTime * speed * 0.3f;
                //print("ReverceGear 1");
            }
            else if (yDirection < -0.3 && yDirection > -0.7)
            {
                clampMovement -= Time.deltaTime * speed * 0.6f;
                //print("ReverceGear 2");
            }
            else if (yDirection < -0.7 && yDirection > -1)
            {
                clampMovement -= Time.deltaTime * speed;
              //  print("ReverceGear 3");
            }
        }


        clampMovement = Mathf.Clamp(clampMovement, yMinValue, yManValue);
		transform.localPosition = new Vector3(0, 2.4f, clampMovement);

		
		//transform.localPosition = new Vector3(0,  2.4f, Mathf.Clamp(transform.localPosition.z, yMinValue, yManValue));
		//transform.Translate(0, Mathf.Clamp(transform.localPosition.y, yMinValue, yManValue), 1);
		//transform.Translate(Vector3.forward * yDirection * Time.deltaTime * speed);

		//print(yDirection);
	}


}

