using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueReference : MonoBehaviour
{
    // Start is called before the first frame update

    // Reference type
    private MyClass myClass;

    private void Start()
    {
        // Value type
        int x = 10;
        int y = x;
        y = 20;
        Debug.Log(x);
        Debug.Log(y);

        // Reference type
        MyClass first = new MyClass();
        first.value = 7;
        MyClass second = first;
        second.value = 5;
        Debug.Log(second.value);
        Debug.Log(first.value);
        
        int i = 5;
        Increment(ref i);
        Debug.Log(i);
    }
    public static void Increment(ref int i)
    {
        i++;
    }
}

    public class MyClass 
    {
        public int value;
    }
    // Update is called once per frame

