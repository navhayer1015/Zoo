using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCameraBase))]
public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera _TransitionTo;

    [SerializeField]
    string _TransitionInput;

    void Update()
    {
        if(Input.GetButtonDown(_TransitionInput))
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
