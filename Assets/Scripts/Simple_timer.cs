using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_timer : MonoBehaviour
{
    private float _startTime;
    float CurTimer;
    private void OnEnable()
    {
        _startTime = GameManager.Instance.MyTimer;
    }

    private void Update()
    {
        CurTimer -= _startTime;
    }
}
