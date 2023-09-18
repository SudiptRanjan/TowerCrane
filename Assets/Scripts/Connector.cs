using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Events;

public class Connector : MonoBehaviour
{
	/*	public float minMassValue = 1f;
		public float maxMassValue = 3f;*/

	public float minAnchorValue = -4f;
	public float maxAnchorValue = 4f;

	private Rigidbody rb;
	[SerializeField] private bool objectAttachable = false;
	[SerializeField] private bool objectAttached = false;
	[SerializeField] private float maxRayLength = 1f;
	[SerializeField] private Container _container;
	[SerializeField] private Transform bottomPoint;
	[SerializeField] private List<SpringJoint> joints;
	private float offset = -1f;

	RaycastHit hit;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		//Events.onObjectInteract += InteractWithObject;
	}
	private void OnDestroy()
	{
		//Events.onObjectInteract -= InteractWithObject;
	}

	private void Update()
	{

		Debug.DrawRay(transform.position, Vector3.down * maxRayLength, Color.yellow);
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, maxRayLength))
		{
			if (hit.collider != null)
			{
				if (!objectAttachable)
				{
					_container = hit.collider.gameObject.GetComponent<Container>();
					if (_container != null)
					{
						objectAttachable = true;
					}
				}
			}
		}
		else
		{
			objectAttachable = false;
		}
	}

	private void FixedUpdate()
	{
		if(InputManager.instance.isShrining)
			IncreaseConnectorMass();
		if(InputManager.instance.looseRope)
			DecreaseConnectorMass();
	}

	public void InteractWithObject()
	{
		if (objectAttachable && !objectAttached)
		{
			// Attached the container
			//_container.ActivateKinematic();
			_container.transform.SetParent(bottomPoint);
			_container.transform.position = transform.position + new Vector3(0f, offset, 0f);
			objectAttached = true;
		}
		else if (objectAttached)
		{
			// Dettached the Container
			//_container.DeactiveKinematic();
			_container.transform.parent = null;
			objectAttachable = false;
			objectAttached = false;
			_container = null;
		}
	}
	public void IncreaseConnectorMass()
	{
		/*rb.mass -= 0.5f * Time.deltaTime;
		rb.mass = Mathf.Clamp(rb.mass, minMassValue, maxMassValue);*/

		foreach (var joint in joints)
		{
			float anchorY = joint.anchor.y;
			anchorY -= Time.deltaTime * 0.5f;
			anchorY = Mathf.Clamp(anchorY, minAnchorValue, maxAnchorValue);
			joint.anchor = new Vector3(0f, anchorY, 0f);
		}
	}

	public void DecreaseConnectorMass()
	{
		/*	rb.mass += 0.5f * Time.deltaTime;
			rb.mass = Mathf.Clamp(rb.mass, minMassValue, maxMassValue);*/

		foreach (var joint in joints)
		{
			float anchorY = joint.anchor.y;
			anchorY += Time.deltaTime * 0.5f;
			anchorY = Mathf.Clamp(anchorY, minAnchorValue, maxAnchorValue);	
			joint.anchor = new Vector3(0f, anchorY, 0f);
		}
	}


}
