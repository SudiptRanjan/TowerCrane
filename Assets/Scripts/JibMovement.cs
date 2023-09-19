using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JibMovement : MonoBehaviour
{
    //private CraneInputActions m_inputaction;
    [SerializeField] float moveSpeed;
    float newRotation = 0;
    [SerializeField] private float yMinValueRotation = 10f, yMaxValueRotation = 60f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        Events.onPlayerRotate += Rotates;
       
    }
    private void OnDisable()
    {
        Events.onPlayerRotate -= Rotates;

    }
   

    private void Rotates(float  rotate)
    {

        ////float newRotation = transform.localRotation.y;
        //newRotation = Mathf.Clamp(newRotation, yMinValueRotation, yMaxValueRotation);
        //transform.localRotation = Quaternion.Euler(new Vector3(0, newRotation,0));

        //transform.Rotate(Vector3.up * rotate * Time.deltaTime * moveSpeed);

        //print(rotate);
        if ( rotate > 0)
        {
            if (rotate > 0 && rotate < 0.3)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.3f;
                //print("Gear 1");
            }
            else if (rotate > 0.3 && rotate < 0.7)
            {
                newRotation += Time.deltaTime * moveSpeed * 0.6f;
                //print("Gear 2");
            }
            else if (rotate > 0.7 && rotate <= 1)
            {
                newRotation += Time.deltaTime * moveSpeed;
                //print("Gear 3");
            }

          

        }
        else if ( rotate < 0)
        {
            if (rotate < 0 && rotate > -0.3)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.3f;
                //print("ReverceGear 1");
            }
            else if (rotate < -0.3 && rotate > -0.7)
            {
                newRotation -= Time.deltaTime * moveSpeed * 0.6f;
                //print("ReverceGear 2");
            }
            else if (rotate < -0.7 && rotate > -1)
            {
                newRotation -= Time.deltaTime * moveSpeed;
                //print("ReverceGear 3");
            }
           
        }

        newRotation = Mathf.Clamp(newRotation, yMinValueRotation, yMaxValueRotation);

        transform.localRotation = Quaternion.Euler(0, newRotation,0);

    }
}
//transform.localRotation = Quaternion.Euler(new Vector3(0f, Mathf.Clamp(transform.localRotation.y, yMinValueRotation, yMaxValueRotation), 0f));
//transform.Rotate(Vector3.forward * rotate * Time.deltaTime * 80);