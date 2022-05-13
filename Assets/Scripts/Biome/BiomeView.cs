using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    Label _shortFact;

    void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    void OnEnable()
    {
        _uiDocument.rootVisualElement.Q<Button>("btnBack").clicked += OnBackButtonPressed;
        _uiDocument.rootVisualElement.Q<Button>("btnNext").clicked += OnNextPressed;
        _uiDocument.rootVisualElement.Q<Button>("btnPrevious").clicked += OnPreviousPressed;

        _animalName = _uiDocument.rootVisualElement.Q<Label>("lblName");
        _scientificName = _uiDocument.rootVisualElement.Q<Label>("lblScientificName");
        _shortFact = _uiDocument.rootVisualElement.Q<Label>("lblFact");
        _habitat = _uiDocument.rootVisualElement.Q<Label>("lblHabitatValue");
        _size = _uiDocument.rootVisualElement.Q<Label>("lblSizeValue");
        _diet = _uiDocument.rootVisualElement.Q<Label>("lblDietValue");
        
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
        _scientificName.text = animalData._scientificNames?.FirstOrDefault();
        _shortFact.text = animalData._shortFact;
        _diet.text = animalData._diet;
        _habitat.text = animalData._habitat;
        _size.text = animalData._size;
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
