using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationUI : MonoBehaviour
{
    public Transform toastParent;
    public GameObject toastPrefab; // prefab should contain a Text component
    public float displayTime = 3f;

    void Awake()
    {
        // Register as NotificationManager consumer
        NotificationManager.Instance.Push("NotificationUI initialized");
        // Hooking up will be done via NotificationManager calling Show
    }

    public void Show(string message)
    {
        if (toastPrefab == null)
        {
            var fallback = Resources.Load<GameObject>("UI/NotificationToast");
            if (fallback != null) toastPrefab = fallback;
        }

        if (toastPrefab == null)
        {
            Debug.Log("No toast prefab assigned or found in Resources/UI/NotificationToast");
            return;
        }

        var toast = Instantiate(toastPrefab, toastParent);
        var txt = toast.GetComponentInChildren<Text>();
        if (txt != null) txt.text = message;
        StartCoroutine(AutoHide(toast));
    }

    IEnumerator AutoHide(GameObject toast)
    {
        yield return new WaitForSeconds(displayTime);
        Destroy(toast);
    }
}
