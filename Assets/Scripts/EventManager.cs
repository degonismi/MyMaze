using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager Instance { get; private set; }
    
    // UI
    public Action<GameState> OnGameStateChangeAction;
    public Action OnGameUIAction;
    public Action OnMenuUIAction;
    
    // GameCycle
    public Action<int> OnRespawnLevelAction;
    public Action<float> OnInputAction;
    public Action<int, LevelState> OnEndLevelAction;

    public Action OnUpdateUIAction;
    public Action OnUpdate;
    public Action OnFixedUpdate;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}
