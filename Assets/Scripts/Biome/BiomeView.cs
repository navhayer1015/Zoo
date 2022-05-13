using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class BiomeView : MonoBehaviour
{
    public UnityEvent onBackButtonPressed;
    
    UIDocument _uiDocument;
    [SerializeField]
    Biome _biome;

    Label _animalName;
    Label _habitat;
    Label _size;
    Label _diet;
    Label _scientificName;

    void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.Q<Button>("btnBack").clicked += OnBackButtonPressed;
        _uiDocument.rootVisualElement.Q<Button>("btnNext").clicked += OnNextPressed;
        _uiDocument.rootVisualElement.Q<Button>("btnPrevious").clicked += OnPreviousPressed;

        _animalName = _uiDocument.rootVisualElement.Q<Label>("lblName");
    }

    void OnEnable()
    {
        _biome.SpawnAnimal();
        InitForBiome(_biome);
    }

    void OnBackButtonPressed()
    {
        onBackButtonPressed.Invoke();
    }

    public void InitForBiome(Biome biome)
    {
        _biome = biome;
        UpdateAnimalInfo();
    }

    void UpdateAnimalInfo()
    {
        var currentAnimal = _biome.GetAnimalDataFromCurrentAnimal();
        InitializeAnimalData(currentAnimal);
    }

    void InitializeAnimalData(AnimalData animalData)
    {
        _animalName.text = animalData._animalName;
    }

    void OnNextPressed()
    {
        _biome.Next();
        UpdateAnimalInfo();
    }

    void OnPreviousPressed()
    {
        _biome.Previous();
        UpdateAnimalInfo();
    }
}
