using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MinigameUIController : MonoBehaviour
{    
    public static MinigameUIController instance;
    //public GameObject minigamePrefab;
    public TMP_Text scoreText, timerText;
    public MinigameEndPanelController minigameEndUI;
    public MinigamePetController minigamePetController;
    public bool victory;
    private int score;
    private float timeRemaining;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one MinigameUIController in the Scene");    

    }

    private void OnEnable()
    {
        // GameObject minigame = Instantiate(minigamePrefab);
        //  minigame.GetComponent<BaseMinigameController>().Initialize(minigamePetController.transform);
        GetComponent<BaseMinigameController>().Initialize(minigamePetController.transform);
    }

    public void UpdateScore(int score) 
    {
        this.score = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        timeRemaining = timer;
        timerText.text = string.Format("Time Left: {0}", timer);
    }

    public void FinishMiniGame(int score, float timeRemaining) 
    {
        minigameEndUI.gameObject.SetActive(true);       
        minigameEndUI.Intialize(score, timeRemaining, timeRemaining >0);
    }

    public void LoseMiniGame() 
    {
        minigameEndUI.gameObject.SetActive(true);
        minigameEndUI.Intialize(score, timeRemaining, false);
    }
}
