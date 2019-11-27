using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopPanel : MonoBehaviour
{
    [SerializeField] private Button _returnButton;
    [SerializeField] private Button _nextColorButton;
    [SerializeField] private Button _prevColorButton;
    [SerializeField] private Button _nextBallButton;
    [SerializeField] private Button _prevBallButton;

    [SerializeField] private Image _playerSkin;
    [SerializeField] private Text _colorText;
    
    [SerializeField] List<Color32> _color32s = new List<Color32>();

    [SerializeField] private List<GameObject> _balls;
    private GameObject _spawnedBall;
    
    private int _skinIndex;
    private int _colorIndex;

    private void Start()
    {
        _returnButton.onClick.AddListener(() =>
        {
            EventManager.Instance.OnGameStateChangeAction?.Invoke(GameState.menu);
        });
        _prevBallButton.onClick.AddListener((() =>
        {
            ChangePlayer(false);
        }));
        _nextBallButton.onClick.AddListener((() =>
        {
            ChangePlayer(true);
        }));

        _spawnedBall = Instantiate(_balls[0], transform.position, Quaternion.identity, _playerSkin.transform);
        _spawnedBall.GetComponent<Rigidbody2D>().gravityScale = 0;
        
        _skinIndex = 0;
    }

    private void ChangePlayer(bool isNext)
    {
        if (isNext)
        {
            _skinIndex += 1;
        }
        else
        {
            _skinIndex -= 1;
        }
        
        if (_skinIndex < 0)
        {
            _skinIndex = 4;
        }
        else if (_skinIndex > 4)
        {
            _skinIndex = 0;
        }
        
        _playerSkin.color = _color32s[_skinIndex];
        
    }
    
}
