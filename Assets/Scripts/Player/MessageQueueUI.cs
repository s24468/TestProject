using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageQueueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float messageDuration = 1f;

    private readonly Queue<string> messageQueue = new();
    private Coroutine messageRoutine;

    private void Awake()
    {
        if (messageText != null)
            messageText.text = "";
    }
    public void EnqueueMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        messageQueue.Enqueue(message);

        if (messageRoutine == null)
        {
            messageRoutine = StartCoroutine(ProcessQueue());
        }
    }

    private IEnumerator ProcessQueue()
    {
        while (messageQueue.Count > 0)
        {
            messageText.text = messageQueue.Dequeue();
            yield return new WaitForSeconds(messageDuration);
            messageText.text = "";
            yield return new WaitForSeconds(0.1f); // mała przerwa dla czytelności
        }

        messageRoutine = null;
    }
    
}
