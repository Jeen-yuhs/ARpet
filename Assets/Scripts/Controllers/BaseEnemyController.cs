using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PLayer")) 
        {            
            MinigameUIController.instance.LoseMiniGame();
        }
    }
}
