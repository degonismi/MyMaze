using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float _input;

    private float _currentInput;
    
    private bool _move;

    [Range(0, 1000)] public float Speed;

    public Rigidbody2D Rigidbody;
    
    private void Start()
    {
        GameManager.Instance.MyGameInput = this;

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _input = Input.mousePosition.x;
        EventManager.Instance.OnUpdate += Move;
    }

    public void Move()
    {
        _currentInput = _input - Input.mousePosition.x;
        _currentInput *= Speed;
        _currentInput = Mathf.Clamp(_currentInput, -300, 300);
        if(Rigidbody)
        Rigidbody.angularVelocity = -_currentInput;
        _input = Input.mousePosition.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.Instance.OnUpdate -= Move;
        _input = 0;
        if(Rigidbody)
        Rigidbody.angularVelocity = _input;
        _move = false;
    }
}
