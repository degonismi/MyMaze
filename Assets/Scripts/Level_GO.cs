using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level_GO : MonoBehaviour
{
  
    
    [SerializeField] private Transform _backGround;
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject PlayerPrefab;

    [SerializeField] private _dataLevels _levels;

    public int Index;
    
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

    private void Start()
    {
        Index = 0;
        _levelPrefab = Instantiate(_levels.Levels_1[Index], transform.position, Quaternion.identity, transform).gameObject;
        _player = Instantiate(PlayerPrefab, transform.position, Quaternion.identity, transform);
    }

    [ContextMenu("Hide")]
    public void HideMaze()
    {
        
    }
    
    public void NextLevel()
    {
        Index++;
        if (Index >= _levels.Levels_1.Count)
        {
            Index = 0;
        }
        
        Destroy(_levelPrefab);
        _levelPrefab = Instantiate(_levels.Levels_1[Index], transform.position, Quaternion.identity, transform).gameObject;
        
        Destroy(_player);
        _player = Instantiate(PlayerPrefab, transform.position, Quaternion.identity, transform);

    }

    public void Restart()
    {
        Destroy(_levelPrefab);
        _levelPrefab = Instantiate(_levels.Levels_1[Index], transform.position, Quaternion.identity, transform).gameObject;
        
        Destroy(_player);
        _player = Instantiate(PlayerPrefab, transform.position, Quaternion.identity, transform);
    }


}
