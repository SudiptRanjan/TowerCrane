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
        //if(rotate ==1)
        //{
        //    newRotation += Time.deltaTime * moveSpeed;
        //}
        //else if(rotate == -1)
        //{
        //    newRotation -= Time.deltaTime * moveSpeed;
        //}
        if (rotate == 1)
        {
            newRotation += Time.deltaTime * moveSpeed;
        }
        else if (rotate == -1)
        {
            newRotation -= Time.deltaTime * moveSpeed;
        }

        newRotation = Mathf.Clamp(newRotation, yMinValueRotation, yMaxValueRotation);

        transform.localRotation = Quaternion.Euler(0, newRotation,0);

    }
}
//transform.localRotation = Quaternion.Euler(new Vector3(0f, Mathf.Clamp(transform.localRotation.y, yMinValueRotation, yMaxValueRotation), 0f));
//transform.Rotate(Vector3.forward * rotate * Time.deltaTime * 80);