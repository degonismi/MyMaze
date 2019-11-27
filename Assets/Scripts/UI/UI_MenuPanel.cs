using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _levelsButton;
    [SerializeField] private Button _shopButton;

    private void Start()
    {
        _startButton.onClick.AddListener(() =>
        {
            ChangeState(GameState.game);
            EventManager.Instance.OnStartGameAction?.Invoke();
        });
        _settingsButton.onClick.AddListener( () => { ChangeState(GameState.settings); });
        _levelsButton.onClick.AddListener( () => { ChangeState(GameState.levels); });
        _shopButton.onClick.AddListener( () => { ChangeState(GameState.shop); });
        
    }

    private void ChangeState(GameState gameState)
    {
        EventManager.Instance.OnGameStateChangeAction?.Invoke(gameState);
    }
}
