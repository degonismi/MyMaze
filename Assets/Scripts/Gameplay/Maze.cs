using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazer
{
    public class Maze : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<GameInput>().Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.localPosition = Vector3.zero;
        }
    }


}
