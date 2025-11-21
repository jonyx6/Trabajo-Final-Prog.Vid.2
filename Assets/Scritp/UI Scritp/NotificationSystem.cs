using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationSystem : MonoBehaviour
{
    private Coroutine notificationCoroutine;
    private static NotificationSystem _instance;
    [SerializeField]
    private TMP_Text notificationText;

    public static NotificationSystem Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    public void ShowMessage(string message ,float time)
    {
        if(notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notificationCoroutine = StartCoroutine(ShowMessageForTime(message,time));
    }
    private IEnumerator ShowMessageForTime(string message ,float time)
    {
        notificationText.text = message;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
}
