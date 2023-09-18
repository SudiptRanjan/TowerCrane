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


    }

    private void OnEnable()
    {
        Events.onRopeValueChange += SetLengthOfRope;

    }
    private void OnDisable()
    {
        Events.onRopeValueChange -= SetLengthOfRope;

    }



    void SetLengthOfRope( float ropeValue)
    {

        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, springJoint.connectedBody.transform.position);
        //if (Input.GetKey(KeyCode.UpArrow))
        //{

        //    springJoint.maxDistance = distanceOfRope += 0.1f;
        //    //springJoint.maxDistance += 0.1f;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    springJoint.maxDistance = distanceOfRope -= 0.1f;
        //    //springJoint.maxDistance -= 0.1f;
        //}
        print(ropeValue);

        if (ropeValue == 1)
        {

            springJoint.maxDistance = distanceOfRope += 0.1f;
            //springJoint.maxDistance += 0.1f;
        }
        if (ropeValue == -1)
        {
            springJoint.maxDistance = distanceOfRope -= 0.1f;
            //springJoint.maxDistance -= 0.1f;
        }
        distanceOfRope = Mathf.Clamp(springJoint.maxDistance, minDistance, maxDistance);

    }

}
