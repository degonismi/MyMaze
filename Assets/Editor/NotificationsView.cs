using System;
using UnityEditor;
using Notifications;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(NotificationManager))]
public class NotificationsView : Editor
{
    private NotificationManager _notificationManager;
    private void OnEnable()
    {
        _notificationManager = (NotificationManager)target;
    }

    public override void OnInspectorGUI()
    {
        
        
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal("Toolbar");
        EditorGUILayout.LabelField("Set Notification time, Type, Text");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        if (_notificationManager.Notifications.Count > 0)
        {
            foreach (var item in _notificationManager.Notifications)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Set Title:", GUILayout.MaxWidth(50), GUILayout.Height(25));
                item.Title = EditorGUILayout.TextField(item.Title, GUILayout.MinWidth(50) );
                if (GUILayout.Button("Delete", GUILayout.Width(70)))
                {
                    _notificationManager.Notifications.Remove(item);
                    break;
                }

                EditorGUILayout.EndHorizontal();
                
                EditorGUILayout.BeginHorizontal(GUILayout.Height(20));
                item.Type = (NotificationManager.NotificationType)EditorGUILayout.EnumPopup(item.Type, GUILayout.Width(100));
                
                EditorGUIUtility.labelWidth = 25;
                item.Day = EditorGUILayout.IntField("Dd:",  item.Day,  GUILayout.MaxWidth(10), GUILayout.MaxWidth(100) );
                EditorGUIUtility.labelWidth = 25;
                item.SetHour =  EditorGUILayout.IntField("Hh:", item.Hour, GUILayout.MaxWidth(10), GUILayout.MaxWidth(100));
                EditorGUIUtility.labelWidth = 25;
                item.SetMinutes = EditorGUILayout.IntField("Mm:", item.Minutes, GUILayout.MaxWidth(10), GUILayout.MaxWidth(100));

                
                
                
                EditorGUILayout.EndHorizontal();
               
                
                if (item.TextNotificatios.Count >0)
                {
                    for (int i = 0; i < item.TextNotificatios.Count; i++)
                    {
                        
                        EditorGUILayout.BeginHorizontal();

                        item.TextNotificatios[i] =  EditorGUILayout.TextField(  item.TextNotificatios[i]);

                        if (i > 0)
                        {
                            if (GUILayout.Button("-", GUILayout.Width(25)))
                            {
                                item.TextNotificatios.Remove(item.TextNotificatios[i]);
                                break;
                            }
                        }
                        
                        EditorGUILayout.EndHorizontal();
                    }
                }
                else
                {
                    item.TextNotificatios.Add("...");
                }
                
                if (GUILayout.Button("Add Note", GUILayout.Width(100)))
                {
                    item.TextNotificatios.Add("...");
                }
                
                
                
                EditorGUILayout.Space();
                //EditorGUILayout.Foldout("Type", item.Type.);
                
                
                
            }
           
        }
        else
        {
            EditorGUILayout.LabelField("Add Notifications");
        }

        EditorGUILayout.BeginHorizontal("MiniButtonMiddle");
        if (GUILayout.Button("Add Notification"))
        {
            _notificationManager.Notifications.Add(new NotificationManager.Notification());
        }

        EditorGUILayout.EndHorizontal();
        if (GUI.changed)
        {
            SetDirty(_notificationManager.gameObject);
        }
    }

    public static void SetDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
}
