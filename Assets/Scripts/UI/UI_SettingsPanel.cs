using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingsPanel : MonoBehaviour
{

    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _vibroButton;
    [SerializeField] private Button _returnButton;
    //[SerializeField] private Button _musicButton;

    private void Start()
    {
        _returnButton.onClick.AddListener((() =>
        {
            EventManager.Instance.OnGameStateChangeAction?.Invoke(GameState.menu);
        }));
        
    }
}
