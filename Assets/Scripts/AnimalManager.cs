using System;
using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using Unity.Mathematics;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] GameObject _currentAnimal;
    [SerializeField] private int _currentAmimalIndex = 0;
    [SerializeField] List<GameObject> _animals;
    
    [EasyButtons.Button]
    public void SpawnAnimal()
    {
        _currentAnimal =  Instantiate(_animals[_currentAmimalIndex],Vector3.zero, Quaternion.identity);
        var skinnedMeshRenderer = _currentAnimal.GetComponentInChildren<SkinnedMeshRenderer>();
        var _animalPos = _currentAnimal.transform.position;
        _animalPos = new Vector3(_animalPos.x, _animalPos.y + math.abs(skinnedMeshRenderer.bounds.size.y), _animalPos.z);
        _currentAnimal.transform.position = _animalPos;
    }
    [Button]
    public void Next()
    {
        DestroyAnimal();
        _currentAmimalIndex++;
        if (_currentAmimalIndex <= _animals.Count - 1)
        {
            _currentAnimal = _animals[_currentAmimalIndex];
        }
        else
        {
            _currentAmimalIndex = 0;
            _currentAnimal = _animals[_currentAmimalIndex];
        }

        SpawnAnimal();
    }
    [Button]
    public void Previous()
    {
        DestroyAnimal();
        _currentAmimalIndex--;
        if (_currentAmimalIndex <= -1)
        {
            _currentAmimalIndex = _animals.Count - 1;
            _currentAnimal = _animals[_currentAmimalIndex];
        }
        else
        {
            _currentAnimal = _animals[_currentAmimalIndex];
        }
        SpawnAnimal();
    }
    
    // Destroy the current environment
    void DestroyAnimal() 
    { 
        DestroyImmediate(_currentAnimal);
    }
    
    
}
