using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailBuilder : MonoBehaviour
{
    [SerializeField] private int _tailSize;
    [SerializeField] private TailPool _tailpool;
    [SerializeField] private float _spaceBetweenBlocks;
    private List<GameObject> _snake = new();
    private Vector3 _snakeDirection = Vector3.up;

    public IReadOnlyList<GameObject> Snake => _snake;


    void Awake()
    {
        _snake.Add(this.transform.GetChild(0).gameObject); // Add head as a first element

        SnakeMovement.OnDirectionChanged += ChangeDirection;

        for (int i = 0; i != _tailSize; i++)
        {
            AddTailBlock();
        }

    }

    private void AddTailBlock()
    {
            GameObject go = _tailpool.TakeTailBlock();
            go.SetActive(true);
            go.transform.SetParent(this.transform);

            Transform LastBlock = _snake[_snake.Count - 1].transform;

            go.transform.position = LastBlock.position - _snakeDirection; 

            _snake.Add(go);
    }

    private void ChangeDirection(Vector3 SnakeDirection)
    {
        _snakeDirection = SnakeDirection;
    }
}

