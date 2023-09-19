using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Events;

public class InputManager : MonoBehaviour
{
	public static InputManager instance;

	private CraneInputActions m_inputaction;
	private float ropeLength, moveZ,  rotateValue, attached, detached;
	
	public bool isShrining = false;
	public bool looseRope = false;	

	private void OnEnable()
	{
		if(instance == null)
		{
			instance = this;
		}
		m_inputaction = new CraneInputActions();
		m_inputaction.Enable();
		m_inputaction.Crane.Movement.performed += OnCraneMoves;
		m_inputaction.Crane.Movement.canceled += OnCraneMoves;
		m_inputaction.Crane.Movement.performed += onCraneRotate;
		m_inputaction.Crane.Movement.canceled += onCraneRotate;
		//m_inputaction.Crane.PickupAndDrop.performed += OnPickUpandDrop;
		m_inputaction.Crane.Rotate.performed += onRopeLengthChange;
        m_inputaction.Crane.Rotate.canceled += onRopeLengthChange;
		m_inputaction.Crane.Rotate.performed += onRopeLengthChange;

		m_inputaction.Crane.Pickup.performed += onObjectAttached;
		m_inputaction.Crane.Pickup.canceled += onObjectAttached;
		m_inputaction.Crane.Drop.performed += onObjectDetached;
		m_inputaction.Crane.Drop.canceled += onObjectDetached;
		//joystick
		m_inputaction.Crane.Joystick.performed += OnCraneMoves;
		m_inputaction.Crane.Joystick.canceled += OnCraneMoves;
		m_inputaction.Crane.Joystick.performed += onCraneRotate;
		m_inputaction.Crane.Joystick.canceled += onCraneRotate;

		m_inputaction.Crane.RightJoystick.performed += onRopeLengthChange;
		m_inputaction.Crane.RightJoystick.canceled += onRopeLengthChange;

	


	}
	private void OnDisable()
	{


		m_inputaction.Crane.Movement.performed -= OnCraneMoves;
		m_inputaction.Crane.Movement.canceled -= OnCraneMoves;
		m_inputaction.Crane.Movement.performed -= onCraneRotate;
		m_inputaction.Crane.Movement.canceled -= onCraneRotate;
		//m_inputaction.Crane.PickupAndDrop.performed -= onRopeLengthChange;
		m_inputaction.Crane.Rotate.performed -= onRopeLengthChange;
        m_inputaction.Crane.Rotate.canceled -= onRopeLengthChange;

		m_inputaction.Crane.Pickup.performed -= onObjectAttached;
		m_inputaction.Crane.Pickup.canceled -= onObjectAttached;
		m_inputaction.Crane.Drop.performed -= onObjectDetached;
		m_inputaction.Crane.Drop.canceled -= onObjectDetached;


		m_inputaction.Dispose();

		//joystick
		m_inputaction.Crane.Joystick.performed -= OnCraneMoves;
		m_inputaction.Crane.Joystick.canceled -= OnCraneMoves;
		m_inputaction.Crane.Joystick.performed -= onCraneRotate;
		m_inputaction.Crane.Joystick.canceled -= onCraneRotate;

		m_inputaction.Crane.RightJoystick.performed -= onRopeLengthChange;
		m_inputaction.Crane.RightJoystick.canceled -= onRopeLengthChange;

	

	}
	private void Update()
	{
		Events.onPlayerMoves?.Invoke( moveZ);
        Events.onPlayerRotate?.Invoke(rotateValue);
		Events.onRopeValueChange?.Invoke(ropeLength);
		Events.onHookDetachedToObject?.Invoke(detached);
		Events.onHookAttachToObject?.Invoke(attached);
	}

	private void OnCraneMoves(InputAction.CallbackContext obj)
	{
		Vector2 value = obj.ReadValue<Vector2>();
        moveZ = value.y;
	}


	private void onCraneRotate(InputAction.CallbackContext obj)
    {
        Vector2 value = obj.ReadValue<Vector2>();
		//rotateValue = value.x;
		rotateValue = value.x;
		
	}

	private void onRopeLengthChange(InputAction.CallbackContext obj)
    {
		Vector2 value = obj.ReadValue<Vector2>();
		ropeLength = value.y;
	

	}
	private void onObjectDetached(InputAction.CallbackContext obj)
    {
		float value = obj.ReadValue<float>();
		detached = value;
    }
	private void onObjectAttached(InputAction.CallbackContext obj)
	{
		float value = obj.ReadValue<float>();
		attached = value;
	}


	
}
