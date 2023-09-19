using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{
   
    [SerializeField] private float radius;
    public Transform hoockConnect;
    public FixedJoint fixedJoint;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.WakeUp();
    
    }

    private void OnEnable()
    {
        Events.onHookAttachToObject += CheckingOfPhysicsBody;
        Events.onHookDetachedToObject += BodyIsDetached;
    }

    private void OnDisable()
    {
        Events.onHookAttachToObject -= CheckingOfPhysicsBody;
        Events.onHookDetachedToObject -=  BodyIsDetached;
    }

    void BodyIsDetached(float detached)
    {
        //print(detached);

        if (detached == 1)
        {

            fixedJoint.connectedBody = null;

        }
    }


    void CheckingOfPhysicsBody(float attached)
    {

        if (attached ==  1)
        {
           
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider grabableObject in hitColliders)
            {
               
                Container grabableContainer = grabableObject.gameObject.GetComponent<Container>();
                //print(grabableContainer);
                if (grabableContainer != null )
                {
                    grabableContainer.transform.position = hoockConnect.transform.position;
                    fixedJoint.connectedBody = grabableContainer.rb;

                }
            }

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 6 && attached)
    //    {
    //        Debug.Log("block");
    //        //other.transform.SetParent(this.transform);
    //        other.transform.position = hoockConnect.transform.position;
    //        fixedJoint.connectedBody = other.attachedRigidbody;



    //    }
    //}
}
