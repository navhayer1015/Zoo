using System;
using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] GameObject _currentEnvironment;
    [SerializeField] private int _currentEnvironmentsIndex = 0;
    [SerializeField] List<GameObject>  _environments;

    
    [Button]
    public void SpawnEnvironment()
    {
        _currentEnvironment = Instantiate(_environments[_currentEnvironmentsIndex],Vector3.zero, Quaternion.identity);
        _currentEnvironment.transform.localScale = new Vector3(7,7,7);
        Camera.main.GetComponent<CameraOrbit>().target = _currentEnvironment;
    }
    
    [Button]
    public void Next()
    {
        DestroyEnvironment();
        _currentEnvironmentsIndex++;
        if (_currentEnvironmentsIndex <= _environments.Count - 1)
        {
            _currentEnvironment = _environments[_currentEnvironmentsIndex];
        }
        else
        {
            _currentEnvironmentsIndex = 0;
            _currentEnvironment = _environments[_currentEnvironmentsIndex];
        }

        SpawnEnvironment();
    }
    [Button]
    public void Previous()
    {
        DestroyEnvironment();
        _currentEnvironmentsIndex--;
        if (_currentEnvironmentsIndex <= -1)
        {
            _currentEnvironmentsIndex = _environments.Count - 1;
            _currentEnvironment = _environments[_currentEnvironmentsIndex];
        }
        else
        {
            _currentEnvironment = _environments[_currentEnvironmentsIndex];
        }
        SpawnEnvironment();
    }
    
    // Destroy the current environment
    void DestroyEnvironment() 
    { 
        DestroyImmediate(_currentEnvironment);
    }
}
