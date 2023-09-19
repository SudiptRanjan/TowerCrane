using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookParent : MonoBehaviour
{
    Rigidbody rb;
    bool sleeping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
            rb.WakeUp();
            //Debug.Log("Increase Leangth");
        
    }
}
