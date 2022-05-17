using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[RequireComponent(typeof(CinemachineVirtualCameraBase))]
public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera _TransitionTo;

    [SerializeField]
    InputAction _TransitionInput;

    void OnEnable()
    {
        _TransitionInput.performed += OnInputReceived;
    }

    void OnDisable()
    {
        _TransitionInput.performed -= OnInputReceived;
    }

    void OnInputReceived(InputAction.CallbackContext callbackContext)
    {
        Transition();
    }

    public void Transition()
    {
        _TransitionTo.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void TransitionAndFocusOn(Transform focusTarget)
    {
        _TransitionTo.Follow = focusTarget;
        _TransitionTo.LookAt = focusTarget;
        
        Transition();
    }
}
