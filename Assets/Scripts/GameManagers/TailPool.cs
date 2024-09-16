using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPool : MonoBehaviour
{
    [SerializeField] private GameObject tailPrefab;
    [SerializeField] private int _poolSize;

    private Stack<GameObject> _tailBlockPool = new();


    void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            CreateTailBlock();
        }
    }


    private GameObject CreateTailBlock()
    {
        GameObject go = Instantiate(tailPrefab);
        go.transform.SetParent(this.transform);
        go.SetActive(false);
        _tailBlockPool.Push(go);
        return go;
    }

    public GameObject TakeTailBlock()
    {
        if (_tailBlockPool.Count > 0)
        {
            return _tailBlockPool.Pop();
        }
        return CreateTailBlock();
    }

}
