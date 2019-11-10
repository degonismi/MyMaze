using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = (1), menuName = "SO/LevelPack", fileName = "LevelPack")]
public class _dataLevels : ScriptableObject
{
    public Level[] Levels_1;
}

[Serializable]
public class Level
{
    [SerializeField] private string Name;
    public float Size = 1;
    public Sprite MazeSprite;
    

}
