using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnaliticsManager : MonoBehaviour
{
    private void Start()
    {
        SendStartLevel();
    }

    public static void SendStartLevel()
    {
        Analytics.CustomEvent("level_start", new Dictionary<string, object>
        {
            {"level", 0}
        });
    }
    
    
}
