using System;
using System.Collections;
using System.Collections.Generic;
using Mazer;
using UnityEngine;

[CreateAssetMenu(order = (1), menuName = "SO/LevelPack", fileName = "LevelPack")]
public class _dataLevels : ScriptableObject
{
    public List<Maze> Levels_1;

    [ContextMenu("SetNames")]
    public void SetNames()
    {
        foreach (var item in Levels_1)
        {
            
        }
    }
    
}

[Serializable]
public class Level
{
    public string Name;
    public float Size = 1;
    public Maze Maze;
    

}
