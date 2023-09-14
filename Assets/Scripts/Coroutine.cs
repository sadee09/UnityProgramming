using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(MoveObject());
    }
    private IEnumerator MoveObject()
    {
        Vector3 position = new Vector3(5f, 0f, 0f);
        float speed = 2f;
        float delay = 3f;

        yield return new WaitForSeconds(delay);

        while (transform.position != position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Object has reached the target position");
    }

    // Update is called once per frame

}
