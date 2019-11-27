using System;
using System.Collections;
using System.Collections.Generic;
using Mazer;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{
    [SerializeField] private Button _startB;
    [SerializeField]  private Button _nextButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Text _levelText;

    public Level_GO LevelGo;
    
    private void Start()
    {
        _startB.onClick.AddListener((() =>
        {
            EventManager.Instance.OnStartGameAction?.Invoke();
        }));
        
        _nextButton.onClick.AddListener(() =>
        {
            LevelGo.NextLevel();
            _levelText.text = FindObjectOfType<Maze>().gameObject.name;
        });
        _resetButton.onClick.AddListener(() =>
        {
            LevelGo.Restart();
            _levelText.text = FindObjectOfType<Maze>().gameObject.name;
        });
        
    }
}
