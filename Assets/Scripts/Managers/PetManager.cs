using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetManager : MonoBehaviour
{
    public Button feedButton, playButton, sleepButton;

    public static PetManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the Scene");
    }

    private void OnEnable()
    {
        PlacementOnMesh_Character.characterPlaced += StartAfterPlacement;
    }

    private void OnDisable()
    {
        PlacementOnMesh_Character.characterPlaced -= StartAfterPlacement;
    }

    private void StartAfterPlacement(NeedsController controller1, PetController controller2)
    {
        feedButton.onClick.RemoveAllListeners();
        playButton.onClick.RemoveAllListeners();
        sleepButton.onClick.RemoveAllListeners();

        feedButton.onClick.AddListener(() => { controller1.ChangeFood(10); });
        playButton.onClick.AddListener(() => { controller1.ChangeHappiness(10); });
        sleepButton.onClick.AddListener(() => { controller1.ChangeEnergy(10); });
    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}
