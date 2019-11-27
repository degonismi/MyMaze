using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMaze : MonoBehaviour
{
    
    
    [ContextMenu("Set")]
    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<SpriteRenderer>().sprite;
        int x = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0,0,x);
    }
}
