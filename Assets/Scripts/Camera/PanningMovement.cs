using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PanningMovement : MonoBehaviour
{
    [SerializeField]
    InputActionReference _PanAction;
    
    [SerializeReference]
    float _speed = 1.0f;

    Vector3 _initialPosition;

    void Awake()
    {
        _initialPosition = transform.position;
    }

    void OnEnable()
    {
        _PanAction.action.Enable();
        _PanAction.action.performed += Move;
    }

    void OnDisable()
    {
        _PanAction.action.Disable();
        _PanAction.action.performed -= Move;
    }

    void Move(InputAction.CallbackContext context)
    {
        transform.position = new Vector3(
            transform.position.x + context.ReadValue<Vector2>().x * Time.deltaTime * _speed, 
            transform.position.y, 
            transform.position.z + context.ReadValue<Vector2>().y * Time.deltaTime * _speed);
    }

    public void Reset()
    {
        transform.position = _initialPosition;
    }
}
