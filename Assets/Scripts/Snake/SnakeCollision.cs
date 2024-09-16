using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    [SerializeField] private FoodPool _foodPool;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _joyStickCanvas;



    public static event Action<GameObject> OnFoodCollision;
    public static event Action OnObstacleCollision;


    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Food>(out Food food))
        {
            OnFoodCollision.Invoke(food.gameObject);
            return;
        }
        OnObstacleCollision.Invoke();
        _gameOverMenu.SetActive(true);
        _joyStickCanvas.SetActive(false);
    }

    private void OnDisable()
    {
        OnFoodCollision = null;
        OnObstacleCollision = null;
    }
}
