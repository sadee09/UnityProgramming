using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    // Cube colors;
    private float red;
    private float green;
    private float blue;
    private float alpha;
    
    // Cube positions;
    private float cubeScale;

    // Cube rotation;
    private float rotSpeed;
    private float rotX;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        InvokeRepeating("ChangeColor", 3.0f, 2.0f);
        InvokeRepeating("ChangeScale", 3.0f,1.0f);
    }

    void Update()
    {
        rotSpeed = Random.Range((float)0, (float)1);
        rotX = Random.Range(0, 360);
        transform.Rotate(rotSpeed * Time.deltaTime * rotX, 0.0f, 0.0f);
    }

    void ChangeColor()
    {
        red = Random.Range((float)0, (float)1);
        green = Random.Range((float)0, (float)1);
        blue = Random.Range((float)0, (float)1);
        alpha = Random.Range((float)0, (float)1);

        Material material = Renderer.material;
        material.color = new Color(red, green, blue, alpha);
    }

    void ChangeScale()
    {
        cubeScale = Random.Range(2,4);
        transform.localScale = Vector3.one * cubeScale;
        
    }
}
