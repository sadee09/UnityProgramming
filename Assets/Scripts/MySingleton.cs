using UnityEngine;

public class MySingleton : MonoBehaviour
{
    private static MySingleton instance;
    private void Awake()
    //instance is available before the scene starts
    //awake is called only once; start may be called multiple times
    //we can singleton instance to be created only once so it is used in awake.
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static MySingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MySingleton>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("MySingleton");
                    instance = obj.AddComponent<MySingleton>();
                }
            } return instance;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * 100f));
    }
}
//Other scripts can then access the
//singleton instance using MySingleton.Instance