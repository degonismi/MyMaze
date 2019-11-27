using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazer
{
    public class Maze : MonoBehaviour
    {
        [Range(0, 50)]
        [SerializeField] private float _fakeMazeSpeed;
        private Rigidbody2D _rigidbody;

        [SerializeField] private AnimationCurve _hideCurve;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            EventManager.Instance.OnInputAction += RotateMaze;

            _fakeMazeSpeed = 4;
            EventManager.Instance.OnStartGameAction += ShowMaze;
        }

        private void RotateMaze(float speed)
        {
            transform.localPosition = Vector3.zero;
            _rigidbody.angularVelocity = -speed;
            
        }

        [ContextMenu("Set")]
        private void ShowMaze()
        {
            var mazes = GetComponentsInChildren<FakeMaze>();
            foreach (var item in mazes)
            {
                StartCoroutine(HideFakeMaze(item.transform));
            }
        }

        private IEnumerator HideFakeMaze(Transform maze)
        {
            float coef;
            
            while (Mathf.Abs(maze.rotation.z)  > 0.01f)
            {
                if ( maze.rotation.z > 0)
                {
                    coef = -_fakeMazeSpeed;
                }
                else
                {
                    coef = _fakeMazeSpeed;
                }
                
                

                maze.Rotate(0,0,coef);
                yield return null;
            }
            Destroy(maze.gameObject);
        }

        private void OnDisable()
        {
            EventManager.Instance.OnInputAction -= RotateMaze;
            EventManager.Instance.OnStartGameAction -= ShowMaze;
        }
    }


}
