using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelPanel : MonoBehaviour
{
    [SerializeField] private Button _returnButton;

    private void Start()
    {
        _returnButton.onClick.AddListener(() =>
        {
            EventManager.Instance.OnGameStateChangeAction?.Invoke(GameState.menu);
        });
    }
}
