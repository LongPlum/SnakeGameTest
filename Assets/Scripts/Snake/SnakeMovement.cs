using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour, IPause
{

    [SerializeField] private float _stepFrequency;
    [SerializeField] private JoystickController _joystickController;


    private TailBuilder _tailBuilder;
    private Vector3 _direction = Vector3.up;
    private float _stepRange = 1;
    private bool _isPaused = true;

    private Vector2 _joystickInput;
    private Vector3 _newDirection;




    public static event Action<Vector3> OnDirectionChanged;


    void Start()
    {
        _tailBuilder = this.GetComponentInParent<TailBuilder>();
        StartButton.OnGameStart += Unpause;
        SnakeCollision.OnObstacleCollision += Pause;
    }


    void Update()
    {
        if (!_isPaused)
        {

          //  KeyboardInput();
            JoystickInput();
        }

    }


    private IEnumerator MoveSnake()
    {
        while (true)
        {
            _joystickInput = _joystickController.InputVector;

            for (int i = _tailBuilder.Snake.Count - 1; i > 0; i--)
            {
                _tailBuilder.Snake[i].transform.position = _tailBuilder.Snake[i - 1].transform.position;
            }

            Debug.Log(_direction);
            transform.position += _direction * _stepRange;

            yield return new WaitForSeconds(_stepFrequency);
        }
    }

    private void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector3.down)
        {
            _direction = Vector3.up;
            OnDirectionChanged.Invoke(_direction);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector3.up)
        {
            _direction = Vector3.down;
            OnDirectionChanged.Invoke(_direction);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector3.right)
        {
            _direction = Vector3.left;
            OnDirectionChanged.Invoke(_direction);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector3.left)
        {
            _direction = Vector3.right;
            OnDirectionChanged.Invoke(_direction);
        }
    }

    private void JoystickInput()
    {
        if (_joystickInput != Vector2.zero)
        {

            if (Mathf.Abs(_joystickInput.x) > Mathf.Abs(_joystickInput.y))
            {
                _newDirection = new Vector3(Mathf.Sign(_joystickInput.x), 0, 0);
            }
            else
            {
                _newDirection = new Vector3(0, Mathf.Sign(_joystickInput.y), 0);
            }

            if ((Vector3.Dot(_newDirection, _direction) >= 0))
            {
                Debug.Log(_newDirection);
                _direction = _newDirection;
                OnDirectionChanged.Invoke(_direction);
            }
        }

    }


    public void Pause()
    {
        _isPaused = true;
        StopAllCoroutines();
    }

    public void Unpause()
    {
        _isPaused = false;
        StartCoroutine(nameof(MoveSnake));
    }

    private void OnDisable()
    {
        OnDirectionChanged = null;
    }

}
