
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
