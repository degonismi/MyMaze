using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = (1), menuName = "SO/GameSettings", fileName = "GameSettings")]
public class _dataGameSettings : ScriptableObject
{
    public float Input;
    public float MaxInput;

    public float DelayForFirstAds;
    public float DelayBetweenAds;
    public int FirstLevelForAds;

    
}
