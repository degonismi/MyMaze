using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_SetButtons : MonoBehaviour
{
    private UI_LevelButton[] _sortedButtons;
    
    public void Awake()
    {
        var _buttons = GetComponentsInChildren<UI_LevelButton>();
        _sortedButtons = new UI_LevelButton[_buttons.Length];

        for (int i = 0; i < _buttons.Length; i++)
        {
            var ind = _buttons[i].Number-1; 
            _sortedButtons[ind] = _buttons[i];
        }

       
    }


    private void Start()
    {
        EventManager.Instance.OnUpdateUIAction += UpdateButtons;
        UpdateButtons();
    }

    private void OnEnable()
    {
        UpdateButtons();
    }

    private void UpdateButtons()
    {
       List<LevelState>  levelsState = new List<LevelState>();
         levelsState  = GameManager.Instance.LevelsState;
       

       for (int i = 0; i < _sortedButtons.Length; i++)
       {
           _sortedButtons[i].SetState(levelsState[i]);
       }
       
    }
    
    
    
    [ContextMenu("Set Buttons")]
    public void SetValues()
    {
        UI_LevelButton[] arr = GetComponentsInChildren<UI_LevelButton>();

        int i = 0;
        foreach (var item in arr)
        {
            i++;
            item.SetValue(i);
        }
    }
}
