using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(order = (1), menuName = "SO/BackGrounds", fileName = "BG_")]
public class _dataBackGrounds : ScriptableObject
{
    
    public List<ColorSet> Sets;


}

[Serializable]
public class ColorSet
{
    public string Name;
    
    public Sprite First;
    public Sprite Second;
    public Sprite Third;
    
}
