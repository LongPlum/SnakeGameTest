using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    private TMP_Text _scoreText;

     void Start()
    {
        _scoreText = gameObject.GetComponent<TMP_Text>();
    }


    void Update()
    {
        _scoreText.text = _scoreManager.Score.ToString();
    }

}
