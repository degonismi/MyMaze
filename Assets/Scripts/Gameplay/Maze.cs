using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazer
{
    public class Maze : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            EventManager.Instance.OnInputAction += RotateMaze;
        }

        private void RotateMaze(float speed)
        {
            transform.localPosition = Vector3.zero;
            _rigidbody.angularVelocity = -speed;
            
        }

        private void OnDisable()
        {
            EventManager.Instance.OnInputAction -= RotateMaze;
        }
    }


}
