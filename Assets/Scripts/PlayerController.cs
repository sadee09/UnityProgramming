
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float horizontalInput;
  public float verticalInput;
  public float speed = 10.0f;
  public float xRange = 10;

  public float zMax =  10;
  public float zMin = 5;
  
  public GameObject projectilePrefab;
  public Transform projectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.x < -xRange)
      {
        transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
      }

      if (transform.position.x > xRange)
      {
        transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
      }
      
      if (transform.position.z > zMax)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
      }

      if (transform.position.z < -zMin)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, -zMin);
      }

      if ( Input.GetKeyDown(KeyCode.Space))
      {
        // launch projectile from player
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation );
      }

      horizontalInput = Input.GetAxis("Horizontal");
      transform.Translate(Vector3.right * (Time.deltaTime * speed * horizontalInput));

      verticalInput = Input.GetAxis("Vertical");
      transform.Translate(Vector3.forward * (Time.deltaTime * speed * verticalInput));

    }
}