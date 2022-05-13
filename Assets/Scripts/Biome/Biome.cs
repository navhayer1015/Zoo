using System;
using System.Collections.Generic;
using EasyButtons;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Biome : MonoBehaviour
{
    [SerializeField] BiomeType _biomeType;
    [Header("Animal Data")]
    [SerializeField] List<GameObject> _animals = new List<GameObject>();
    [SerializeField] GameObject _currentAnimal;
    [SerializeField] private int _currentAmimalIndex = 0;
    [SerializeField] private AnimalData _currentAnimalData;
    
    [Header("Environment Data")]
    [SerializeField] List<GameObject>  _environments = new List<GameObject>();
    [SerializeField] GameObject _currentEnvironment;
    [SerializeField] private int _currentEnvironmentsIndex = 0;
    
    #region Animal Properties
    [Button]
    public void SpawnAnimal()
    {
        print(_biomeType.ToString());
        var spawnPoint = GameObject.Find(_biomeType.ToString()).transform.GetChild(0);
        print(spawnPoint.name);
        _currentAnimal = Instantiate(_animals[_currentAmimalIndex], Vector3.zero, Quaternion.identity,spawnPoint.transform);
        _currentAnimalData = _currentAnimal.GetComponent<AnimalData>();
        _currentAnimal.transform.position = spawnPoint.transform.position;
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
    void DestroyAnimal()
    {
        DestroyImmediate(_currentAnimal);
    }

    public AnimalData GetAnimalDataFromCurrentAnimal()
    {
        return _currentAnimalData;
    }

    #endregion
    #region Load Data List
    [Button]
    public void RefreshData()
    {
        LoadAnimalList();
        LoadEnvironmentList();
    }
    public void LoadAnimalList()
    {
        _animals.Clear();
        var path = "3D/" + _biomeType.ToString() + "/Animals";
        var assetAnimals = Resources.LoadAll(path);
        foreach (var animal in assetAnimals)
        {
            _animals.Add(animal as GameObject);
        }
        _currentAnimal = _animals[0];
    }
    public void LoadEnvironmentList()
    {
        _environments.Clear();
        var path = "3D/" + _biomeType.ToString() + "/Environment";
        var assetEnvironment = Resources.LoadAll(path);
        foreach (var env in assetEnvironment)
        {
            _environments.Add(env as GameObject);
        }
        _currentEnvironment = _environments[0];
    }
    #endregion
}

[Serializable]
public enum BiomeType
{
    Arctic,
    Forest,
    Savanna,
    Mountain
}