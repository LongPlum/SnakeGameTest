using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _startScreenCanvas;
    [SerializeField] private GameObject _joyStickCanvas;
    [SerializeField] private GameObject _HUDCanvas;



    public static event Action OnGameStart;
    public void GameStart()
    {
        OnGameStart.Invoke();
        _startScreenCanvas.SetActive(false);
        _joyStickCanvas.SetActive(true);
        _HUDCanvas.SetActive(true);
    }
    private void OnDisable()
    {
        OnGameStart = null;
    }
}
