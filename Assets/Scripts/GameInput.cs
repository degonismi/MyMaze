using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float _input;

    private EventTrigger _eventTrigger;
    public float MyInput => _input;

    private float _currentInput;
    
    private bool _move;
    public GameObject maze;

    [Range(0, 10)] public float Speed;

    public Rigidbody2D Rigidbody2D;
    
    private void Start()
    {
        GameManager.Instance.MyGameInput = this;

        
    }

    private void Update()
    {
        if (_move)
        {
            Move();    
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _input = Input.mousePosition.x;
        _move = true;
    }

    public void Move()
    {
        _currentInput = _input - Input.mousePosition.x;
        //GameManager.Instance.MyInput = _currentInput;
        _currentInput *= Speed;
        _currentInput = Mathf.Clamp(_currentInput, -300, 300);
        Rigidbody2D.angularVelocity = -_currentInput;
        _input = Input.mousePosition.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = 0;
        Rigidbody2D.angularVelocity = _input;
        _move = false;
    }
}
