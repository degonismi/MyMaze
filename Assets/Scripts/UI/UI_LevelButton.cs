using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_LevelButton : MonoBehaviour
{
    
    
   public int Number;
   public Image Circle;
   public Text LevelText;
   public Image[] Stars;

   public Color32 Dark; 
   public Color32 Light;
   
   
   private void OnValidate()
   {
       GetComponentInChildren<Text>().text = Number.ToString();
   }

   public void SetState(LevelState levelState)
   {
       switch (levelState)
       {
           case LevelState.close:
               Stars[0].gameObject.SetActive(false);
               Stars[1].gameObject.SetActive(false);
               Stars[2].gameObject.SetActive(false);

               Circle.color = Dark;
               LevelText.color = Dark;
               
               break;
           case LevelState.open:
               Stars[0].gameObject.SetActive(false);
               Stars[1].gameObject.SetActive(false);
               Stars[2].gameObject.SetActive(false);
               
               Circle.color = Dark;
               LevelText.color = Light;
               
               break;
           case LevelState.star_1:
               Stars[0].gameObject.SetActive(true);
               Stars[1].gameObject.SetActive(false);
               Stars[2].gameObject.SetActive(false);
               
               Circle.color = Light;
               LevelText.color = Light;
               
               break;
           case LevelState.star_2:
               Stars[0].gameObject.SetActive(true);
               Stars[1].gameObject.SetActive(true);
               Stars[2].gameObject.SetActive(false);
               
               Circle.color = Light;
               LevelText.color = Light;
               
               break;
           case LevelState.star_3:
               Stars[0].gameObject.SetActive(true);
               Stars[1].gameObject.SetActive(true);
               Stars[2].gameObject.SetActive(true);
               
               Circle.color = Light;
               LevelText.color = Light;
               
               break;
           
       }
   }
   
   public void SetValue(int number)
   {
       GetComponentInChildren<Text>().text = number.ToString();
       Number = number;
   }

}
