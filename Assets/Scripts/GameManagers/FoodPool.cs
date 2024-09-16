using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPool : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private int _poolSize;

    private Stack<GameObject> _foodPool = new();


    void Awake()
    {
        SnakeCollision.OnFoodCollision += ReleaseFood;

        for (int i = 0; i < _poolSize; i++)
        {
            CreateFood();
        }
    }


    private GameObject CreateFood()
    {
        GameObject go = Instantiate(foodPrefab);
        ReleaseFood(go);
        return go;
    }

    private void ReleaseFood(GameObject go)
    {
        go.transform.SetParent(this.transform);
        go.SetActive(false);
        _foodPool.Push(go);
    }

    public GameObject TakeFood()
    {
        if (_foodPool.Count > 0)
        {
            return _foodPool.Pop();
        }
        return CreateFood();
    }

  

}
