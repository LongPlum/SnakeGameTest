using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    
    [SerializeField] private float _stepFrequency;

    private TailBuilder _tailBuilder;
    private Vector3 _direction = Vector3.up;
    private float _stepRange = 1;

    public static event Action<Vector3> OnDirectionChanged;


    void Start()
    {
        _tailBuilder = this.GetComponentInParent<TailBuilder>();

        StartCoroutine("MoveSnake");
    }


    void Update()
    {
        // Управление направлением змейки
        if (Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector3.down)
        {
            _direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector3.up)
        {
            _direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector3.right)
        {
            _direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector3.left)
        {
            _direction = Vector3.right;
        }

        OnDirectionChanged.Invoke(_direction);
    }


    private IEnumerator MoveSnake()
    {
        while (true)
        {


            for (int i = _tailBuilder.Snake.Count - 1; i > 0; i--)
            {
                _tailBuilder.Snake[i].transform.position = _tailBuilder.Snake[i - 1].transform.position;
            }

            transform.position += _direction * _stepRange;

            yield return new WaitForSeconds(_stepFrequency);
        }
    }
}
