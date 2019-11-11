using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

   public GameInput MyGameInput;
   public float MyInput;

   public float MyTimer;
   
   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   
   
}
