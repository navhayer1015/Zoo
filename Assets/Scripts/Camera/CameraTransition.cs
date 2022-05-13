using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCameraBase))]
public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    GameObject _TransitionTo;

    [SerializeField]
    string _TransitionInput;

    void Update()
    {
        if(Input.GetButtonDown(_TransitionInput))
            Transition();
    }

    public void Transition()
    {
        _TransitionTo.SetActive(true);
        gameObject.SetActive(false);
    }
}
