using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class ExtensionMethod : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        string msg = "Hello, Cube here !";
        string capitalizedMsg = msg.CapitalizeLetter();
        Debug.Log(capitalizedMsg);
    }
}
