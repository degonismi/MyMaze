using System;
using System.Collections;
using System.Collections.Generic;
using Mazer;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{
    [SerializeField] private Button _startB;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Text _levelText;
    [SerializeField] private Button _nextGood;
    [SerializeField] private Button _nextBad;

    public Level_GO LevelGo;
    
    private void Start()
    {
        _startB.onClick.AddListener((() =>
        {
            EventManager.Instance.OnStartGameAction?.Invoke();
        }));
        
        _resetButton.onClick.AddListener(() =>
        {
            LevelGo.Restart();
            _levelText.text = FindObjectOfType<Maze>().gameObject.name;
        });
        
        _nextGood.onClick.AddListener(() =>
        {
            LevelGo.NextLevel(true);
            _levelText.text = FindObjectOfType<Maze>().gameObject.name;
        });
        
        _nextBad.onClick.AddListener(() =>
        {
            LevelGo.NextLevel(false);
            _levelText.text = FindObjectOfType<Maze>().gameObject.name;
        });
        
    }
}
