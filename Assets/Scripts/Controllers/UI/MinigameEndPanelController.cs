using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MinigameEndPanelController : MonoBehaviour
{
    public TMP_Text resultText, titleText;

    public void Intialize(int score, float timeRemaining, bool victory) 
    {
        resultText.text = string.Format("You obtained {0} points, and You had {0} sec left", score, timeRemaining);        
        titleText.text = victory ? "You won!" : "You lost!";
    }
}
