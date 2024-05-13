using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BaseMinigameController : MonoBehaviour
{
    protected int score;
    public float timer;
    public Transform[] startingPositions; // do I neede it?
  
    protected void Start() 
    {
        if (timer == 0) 
        {
            ChangeTimer(30);
        }
    }

    public void Initialize(Transform pet)  // do I neede it?
    {
        transform.position = Vector3.zero;
        pet.position = startingPositions[Random.Range(0, startingPositions.Length)].position;
    }
    protected virtual void ChangeScore(int amount) 
    {
        score += amount;
        if (MinigameUIController.instance == null) return;
        MinigameUIController.instance.UpdateScore(score);
    }

    protected virtual void ChangeTimer(float change) 
    {
        timer += change;
        if (MinigameUIController.instance == null) return;
        MinigameUIController.instance.UpdateTimer(timer);
    }

    protected virtual void Update() 
    { 
        ChangeTimer(-Time.deltaTime);
        if (timer < 0) 
        {
            MinigameUIController.instance.FinishMiniGame(score, timer);
            Destroy(gameObject, 1);
        }
    }

    protected virtual void GoalReached() 
    {
        if (MinigameUIController.instance == null) return;
        MinigameUIController.instance.FinishMiniGame(score, timer);
        Destroy(gameObject);
    }
}
