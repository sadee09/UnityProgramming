using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    private Queue<string> messageQueue = new Queue<string>();

    private void Awake()
    {
        EnqueueMsg("Hiiiii");
        EnqueueMsg("Goodbye");
    }

    private void Start()
    {
        if (messageQueue.Count > 0)
        {
            string message = messageQueue.Dequeue();
            DisplayMsg(message);
        }
        else
        {
            Debug.Log("No more messages");
        }
    }


    private void EnqueueMsg(string message)
    {
        messageQueue.Enqueue(message);
    }

    private void DisplayMsg(string message)
    {
        Debug.Log(message);
    }
    private void OnApplicationQuit()
    {
        if (messageQueue.Count > 0)
        {
            string message = messageQueue.Dequeue();
            DisplayMsg(message);
        }
    }
}
