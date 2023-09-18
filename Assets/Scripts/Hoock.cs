using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{
    [SerializeField] private bool attached = false;
    [SerializeField] private float radius;
    public Transform hoockConnect;
    public FixedJoint fixedJoint;

    void Update()
    {
      
        CheckingOfPhysicsBody();
    }


    void CheckingOfPhysicsBody()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            attached = false;
            fixedJoint.connectedBody = null;

        }

        if (Input.GetKeyDown(KeyCode.G) )
        {
            attached = true;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider grabableObject in hitColliders)
            {
               
                Container grabableContainer = grabableObject.gameObject.GetComponent<Container>();
                print(grabableContainer);
                if (grabableContainer != null &&  attached)
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
