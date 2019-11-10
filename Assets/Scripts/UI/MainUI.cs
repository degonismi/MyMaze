using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        GetComponent<Animator>().SetTrigger("ToGame");
    }
}
