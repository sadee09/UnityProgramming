using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private Stack<string> sceneStack = new Stack<string>();

    private void Start()
    {
        sceneStack.Push("scene 1");
        sceneStack.Push("scene 2");
        sceneStack.Push("scene 3");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (sceneStack.Count > 0)
            {
                string scene = sceneStack.Pop();
                LoadScene(scene);
            }
            else
            {
                Debug.Log("no more scenes left");
            }
        }
    }

    private void LoadScene(string scene)
    {
        Debug.Log("Loading scene" + scene);
    }
}
