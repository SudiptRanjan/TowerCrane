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
	private float ropeLength, moveZ,  rotateValue;
	

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
		m_inputaction.Crane.Movement.performed += onCraneRotate;
        //m_inputaction.Crane.ShrinkRope.performed += OnRopeShrinkEnable;
        //      m_inputaction.Crane.ShrinkRope.canceled += OnRopeShrinkDisable;
        //      m_inputaction.Crane.LooseRope.performed += OnRopeLooseEnable;
        //      m_inputaction.Crane.LooseRope.canceled += OnRopeLooseDisable;
        //m_inputaction.Crane.PickupAndDrop.performed += OnPickUpandDrop;
        m_inputaction.Crane.Rotate.performed += onRopeLengthChange;
	}
	private void OnDisable()
	{
		m_inputaction.Crane.Movement.performed -= OnCraneMoves;
		m_inputaction.Crane.Movement.performed -= onCraneRotate;
        //m_inputaction.Crane.ShrinkRope.performed -= OnRopeShrinkEnable;
        //      m_inputaction.Crane.ShrinkRope.canceled -= OnRopeShrinkDisable;
        //      m_inputaction.Crane.LooseRope.performed -= OnRopeLooseEnable;
        //      m_inputaction.Crane.LooseRope.canceled -= OnRopeLooseDisable;
        //m_inputaction.Crane.PickupAndDrop.performed -= onRopeLengthChange;
        m_inputaction.Crane.Rotate.performed -= onRopeLengthChange;
		m_inputaction.Dispose();
	}
	private void Update()
	{
		Events.onPlayerMoves?.Invoke( moveZ);
        Events.onPlayerRotate?.Invoke(rotateValue);
		Events.onRopeValueChange?.Invoke(ropeLength);
	}

	private void OnCraneMoves(InputAction.CallbackContext obj)
	{
		Vector3 value = obj.ReadValue<Vector3>();
        moveZ = value.y;
	}


	private void onCraneRotate(InputAction.CallbackContext obj)
    {
        Vector3 value = obj.ReadValue<Vector3>();
		//rotateValue = value.x;
		rotateValue = value.x;
		
	}

	private void onRopeLengthChange(InputAction.CallbackContext obj)
    {
		Vector3 value = obj.ReadValue<Vector3>();
		ropeLength = value.x;
	}

	private void OnRopeShrinkEnable(InputAction.CallbackContext obj)
	{
		 isShrining = true;
	}
	private void OnRopeShrinkDisable(InputAction.CallbackContext obj)
	{
		isShrining = false;
	}
	private void OnRopeLooseEnable(InputAction.CallbackContext obj)
	{
		looseRope = true;
	}
	private void OnRopeLooseDisable(InputAction.CallbackContext obj)
	{
		looseRope = false;
	}

	//private void OnPickUpandDrop(InputAction.CallbackContext obj)
	//{
	//	Events.onObjectInteract?.Invoke();
	//}
}
