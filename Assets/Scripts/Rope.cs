
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
     public  SpringJoint springJoint;
     public  LineRenderer line;
     public float distanceOfRope, minDistance = 3f, maxDistance = 15f;


    //Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
       
    }


    void Update()
    {
        SetLengthOfRope();
    }



    void SetLengthOfRope()
    {

        distanceOfRope = Mathf.Clamp(springJoint.maxDistance, minDistance, maxDistance);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, springJoint.connectedBody.transform.position);
        if (Input.GetKey(KeyCode.UpArrow))
        {

            springJoint.maxDistance = distanceOfRope += 0.1f;
            //springJoint.maxDistance += 0.1f;
            //Debug.Log("executing");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            springJoint.maxDistance = distanceOfRope -= 0.1f;
            //springJoint.maxDistance -= 0.1f;
        }

    }

}
