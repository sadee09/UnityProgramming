using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int lives = 5;
    private int score = 0;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLives(int value)
    {
        lives += value;

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            lives = 0;
            // Destroy(Player);
        }
        Debug.Log("Lives = " + lives);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }
}
