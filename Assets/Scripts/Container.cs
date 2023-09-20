using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
	public Rigidbody rb;

    private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        rb.WakeUp();
    }
}
