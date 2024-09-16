using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private FoodPool _foodPool;
    [SerializeField] private Transform _fieldTransform;

    private float _offset = 1;

    void Awake()
    {
        SnakeCollision.OnFoodCollision += SpawnFoodOnCollision;
    }

    private void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        GameObject food = _foodPool.TakeFood();
        food.SetActive(true);

        Vector2 FieldSize = new Vector2(_fieldTransform.lossyScale.x / 2, _fieldTransform.lossyScale.y / 2);

        food.transform.position = new Vector3(UnityEngine.Random.Range(-FieldSize.x + _offset, FieldSize.x - _offset),  
            UnityEngine.Random.Range(-FieldSize.y + _offset, FieldSize.y - _offset), 0);
    }

    private void SpawnFoodOnCollision(GameObject go)
    {
        SpawnFood();
    }
}