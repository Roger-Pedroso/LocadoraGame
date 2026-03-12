using UnityEngine;
using System.Collections.Generic;

public class NotificationManager : MonoBehaviour
{
    private static NotificationManager _instance;
    public static NotificationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("NotificationManager");
                _instance = obj.AddComponent<NotificationManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    private Queue<string> queue = new Queue<string>();

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void Push(string message)
    {
        queue.Enqueue(message);
        Debug.Log("NOTIFICATION: " + message);
        // If a NotificationUI exists in the scene, forward message
        var ui = Object.FindObjectOfType<NotificationUI>();
        if (ui != null) ui.Show(message);
        // Otherwise keep queued for later
    }
}
