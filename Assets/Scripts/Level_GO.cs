using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level_GO : MonoBehaviour
{
  
    
    [SerializeField] private Transform _backGround;
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _player;

    
    private float _yPos; 
    private float YPos
    {
        get => _yPos;
        set
        {
            _yPos = value;
            UpdateLevelPos();
        }
    }

    
    private void UpdateLevelPos()
    {
        _player.transform.position = new Vector3(0, YPos, 0);
        _levelPrefab.transform.position = new Vector3(0, YPos, 0);
    }

    public void StartGame()
    {
        
    }
    
    public void ChangeLevel(GameObject level)
    {
        if (_levelPrefab)
        {
            Destroy(_levelPrefab);
        }
        _levelPrefab = Instantiate(level, new Vector3(0,YPos,0), Quaternion.identity, transform);
        
    }

    public void ChangePlayer(GameObject player)
    {
        if (_player)
        {
            Destroy(_player);
        }
        _player = Instantiate(player, new Vector3(0,YPos,0), Quaternion.identity, transform);
    }

    public void ChangeBackGround(Sprite newBG)
    {
        _backGround.GetComponent<SpriteRenderer>().sprite = newBG;
        
    }

    
}
