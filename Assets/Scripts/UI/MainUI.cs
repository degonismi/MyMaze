using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //_animator.SetTrigger("ToMenu");
        EventManager.Instance.OnGameStateChangeAction += ChangeGameState;
    }

    private void ChangeGameState(GameState gameState)
    {
        string trigger = "";
        switch (gameState)
        {
            case GameState.menu:
                trigger = "ToMenu";
                break;
             case GameState.game:
                trigger = "ToGame";
                break;
             case GameState.settings:
                trigger = "ToSettings";
                break;
             case GameState.shop:
                trigger = "ToShop";
                break;
             case GameState.levels:
                trigger = "ToLevels";
                break;
            
        }
        _animator.SetTrigger(trigger);
    }
    
}
