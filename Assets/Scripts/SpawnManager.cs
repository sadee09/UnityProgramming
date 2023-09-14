
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] animalPrefabs;
  private float spawnPosZ = 20;
  private float spawnRangeX = 20;
  private float startDelay = 2;
  private float intervalDelay = 3.5f;

  public float sideSpawnMinZ;
  public float sideSpawnX;
  public float sideSpawnMaxZ;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, intervalDelay);
        InvokeRepeating("LeftSpawnAnimal", startDelay, intervalDelay);
        InvokeRepeating("RightSpawnAnimal", startDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimal(){

      int animalIndex = Random.Range(0, animalPrefabs.Length);
      Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0 , spawnPosZ);
      Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void LeftSpawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(-sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex],spawnPos,Quaternion.Euler(rotation));
    }

    void RightSpawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(-sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
