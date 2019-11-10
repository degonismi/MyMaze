using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications;
using Unity.Notifications.Android;
using UnityEngine.UI;

namespace Notifications
{
public class NotificationManager : MonoBehaviour
{
    public enum NotificationType
    {
       
        AfterTime,
        Intime,
        IntimeRepeatable
    }
    
    private AndroidNotificationChannel notificationChanal;
    private int indef;

    private int Hours = 12;

    public List<Notification>  Notifications = new List<Notification>();
    

    void Start()
    {
        notificationChanal = new AndroidNotificationChannel()
        {
            Id = "0",
            Name = "main chanel",
            Description = "all notifications",
            Importance = Importance.Default,
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChanal);

        if (Notifications.Count > 0)
        {
            foreach (var item in Notifications)
            {
                SetNotification(item);
            }
        }
        
        
        /*
       DateTime t = DateTime.Now.AddHours(2);
       t.AddHours(2);
       int hours = 24 - t.Hour;
       Debug.Log(t);
       
      
       AndroidNotification notification = new AndroidNotification()
       {
           Title = "1",
           Text = "2",
           SmallIcon = "sml",
           LargeIcon = "big",
           
           
           FireTime = t.AddHours(hours + 12),
           
       };
       
       
       
      // t.AddMinutes(2);
       ;
       Debug.Log(t.AddMinutes(30));
       indef = AndroidNotificationCenter.SendNotification(notification, "main");
       */
    }

    private void SetNotification(Notification note)
    {
        DateTime t = DateTime.Now;
        if (note.Type == NotificationType.AfterTime)
        {
            
           t =  t.AddDays(note.Day).AddHours(note.Hour).AddMinutes(note.Minutes);
            //Debug
        }
        else
        {
            int hours = 24 - t.Hour;

            if (t.Hour < note.Hour)
            {
                t = t.AddHours(note.Hour - t.Hour).AddDays(1);
                 
            }
            else
            {
                t = t.AddHours(24 - t.Hour + note.Hour);
            }

            t = t.AddDays(note.Day);

            if (note.Type == NotificationType.IntimeRepeatable)
            {
                int i = 5;
                while (i > 0)
                {
                    i--;
                }
            }
        }
        Debug.Log(t + note.Type.ToString());


        AndroidNotification notification = new AndroidNotification()
        {
            Title = note.Title,
            Text = note.TextNotificatios[0],
            SmallIcon = "sml",
            LargeIcon = "big",
            FireTime = t,
        };
        AndroidNotificationCenter.SendNotification(notification, "main");
        //return notification;
    }

    private void SetTimeForNotification()
    {
        
    }
    
    
    
    [System.Serializable]
    public class Notification
    { 
        public String Title;
        public NotificationType Type;
        public int Day;
        public int Hour; 
        public int SetHour
        {
        get { return Hour;}
            set
            {
                if (value >=0 & value< 24)
                {
                    Hour = value;
                }
            }
        }

        public int Minutes; 
        public int SetMinutes
        {
        
            get { return Minutes;}
            set
            {
                if (value >=0 & value< 60)
                {
                    Minutes = value;
                }
            }
        }

        
        public List<String> TextNotificatios = new List<string>();
    }

}


   

   
}
