using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float _input;
    private float _currentInput;

    [Range(0, 1000)] public float Speed;

    private void Start()
    {
        EventManager.Instance.OnFixedUpdate += SendInput;
    }

    private void SendInput()
    {
        EventManager.Instance.OnInputAction?.Invoke(_currentInput);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentInput = 0;
        _input = Input.mousePosition.x;
        EventManager.Instance.OnUpdate += Move;
    }

    private void Move()
    {
        _currentInput = _input - Input.mousePosition.x;
        _currentInput *= Speed;
        _currentInput = Mathf.Clamp(_currentInput, -225, 225);
        _input = Input.mousePosition.x;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventManager.Instance.OnUpdate -= Move;
        _currentInput = 0;
        _input = 0;
    }
}
