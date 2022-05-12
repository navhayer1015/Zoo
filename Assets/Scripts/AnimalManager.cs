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
    
    [Button]
    public void SpawnAnimal()
    {
        _currentAnimal =  Instantiate(_animals[_currentAmimalIndex],Vector3.zero, Quaternion.identity);
        var boxCollider = _currentAnimal.GetComponentInChildren<BoxCollider>();
        var animalPos = _currentAnimal.transform.position;
        animalPos = new Vector3(animalPos.x, animalPos.y + math.abs(boxCollider.bounds.size.y), animalPos.z);
        _currentAnimal.transform.position = animalPos;
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
