using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeInit : MonoBehaviour
{
    void Awake () {
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init("909634c0df30d00b2c617252d3d0a064");
        
        Amplitude.Instance.logEvent("start_app");
    }
}
