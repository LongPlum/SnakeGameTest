using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int _fps = 60;
    private void Awake()
    {
        Application.targetFrameRate = _fps;
    }
}
