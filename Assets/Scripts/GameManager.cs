using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
   
   public List<LevelState>  LevelsState;
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

      if (PlayerPrefs.HasKey("Save"))
      {
         LoadGame();
      }
      else
      {
         LevelsState = new List<LevelState>();
         LevelsState.Add(LevelState.open);
         
         int level = 1;
         while (level < 30)
         {
            LevelsState.Add(LevelState.close);
            level++;
         }
         SaveGame();
      }

      Application.targetFrameRate = 60;
   }

   private void Start()
   {
      EventManager.Instance.OnEndLevelAction += SetLevelState;
   }

   private void SetLevelState(int index, LevelState levelState)
   {
      LevelsState[index] = levelState;
      if (LevelsState[index + 1] == LevelState.close)
      {
         LevelsState[index + 1] = LevelState.open;
      }
      SaveGame();

   }

   public int Level;
   public LevelState LevelState;

   public void OpenLevel()
   {
      LevelsState[Level] = LevelState;
      if (LevelsState[Level + 1] == LevelState.close)
      {
         LevelsState[Level + 1] = LevelState.open;
      }
      SaveGame();
      EventManager.Instance.OnUpdateUIAction?.Invoke();
   }
   
   private void SaveGame()
   {
      var save = new Save {Levels = LevelsState};
      var saveString = JsonUtility.ToJson(save);
      PlayerPrefs.SetString("Save", saveString);
   }

   private void LoadGame()
   {
      var load = PlayerPrefs.GetString("Save");
      var save = JsonUtility.FromJson<Save>(load);
      LevelsState = save.Levels;
   }
   
   private class Save
   {
      public List<LevelState> Levels = new List<LevelState>();
   }
   
      
}
public enum LevelState
{
   close, 
   open,
   star_1,
   star_2,
   star_3,
}

public enum GameState
{
   menu,
   game,
   endgame,
   shop,
   levels,
   settings
}