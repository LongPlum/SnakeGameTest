using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }


     void Start()
    {
        SnakeCollision.OnFoodCollision += UpdateScore;
    }

    private void UpdateScore(GameObject go)
    {
        Score += 10;
    }
}
