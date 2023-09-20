using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public SpringJoint springJoint;
    public LineRenderer line;
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



    void SetLengthOfRope(float ropeValue)
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
        //print(ropeValue);

        //if (ropeValue == 1 || ropeValue >0)
        //{

        //    springJoint.maxDistance = distanceOfRope += 0.1f;
        //    //springJoint.maxDistance += 0.1f;
        //}
        //if (ropeValue == -1 || ropeValue < 0)
        //{
        //    springJoint.maxDistance = distanceOfRope -= 0.1f;
        //    //springJoint.maxDistance -= 0.1f;
        //}
        //print(ropeValue);
        if ( ropeValue > 0)
        {
            if (ropeValue < 0.3)
            {
                springJoint.maxDistance = distanceOfRope += 0.03f;
                print("Gear 1= ");
            }
            else if ( ropeValue < 0.7)
            {
                springJoint.maxDistance = distanceOfRope += 0.07f;
                print("Gear 2 " );
            }
            else if ( ropeValue <= 1)
            {
                springJoint.maxDistance = distanceOfRope += 0.1f;
                print("Gear 3  ");
            }
        }
        else if ( ropeValue < 0)
        {
            if (ropeValue > -0.3)
            {
                springJoint.maxDistance = distanceOfRope -= 0.03f;
                print("ReverceGear 1");
            }
            else if (  ropeValue > -0.7)
            {
                springJoint.maxDistance = distanceOfRope -= 0.07f;
                print("ReverceGear 2");
            }
            else if ( ropeValue >= -1)
            {
                springJoint.maxDistance = distanceOfRope -= 0.1f;
                print("ReverceGear 3");
            }
        }



        distanceOfRope = Mathf.Clamp(springJoint.maxDistance, minDistance, maxDistance);

    }

}