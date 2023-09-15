using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JibMovement : MonoBehaviour
{
    private CraneInputActions m_inputaction;
    [SerializeField] float moveSpeed;
    [SerializeField] private float yMinValueRotation = 0f, yManValueRotation = 360f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        Events.onPlayerRotate += Rotates;
        //Events.onPlayerRotate += Rotate;
    }
    private void OnDisable()
    {
        Events.onPlayerRotate -= Rotates;
        //Events.onPlayerRotate -= Rotate;

    }
    private void Rotates(float  rotate)
    {

        //transform.localRotation = Quaternion.Euler( new Vector3(0,  Mathf.Clamp(transform.localRotation.y, yMinValueRotation, yManValueRotation),0));
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * moveSpeed);
        //transform.Rotate(Vector3.forward * rotate * Time.deltaTime * 80);

        
    }
}
