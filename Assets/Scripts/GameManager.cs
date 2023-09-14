
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static float score;
    private static Transform player;
    public float jumpForce = 5f;
    private Rigidbody rb;
    
    private void Start()
    {
        // Assign the player's transform to the GameManager
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Events enemy = FindObjectOfType<Events>();
        // Subscribe to the enemy death event
        enemy.OnEnemyDeath += HandleEnemyDeath;

        rb = GetComponent<Rigidbody>();
        EventSecond spaceInput = FindObjectOfType<EventSecond>();
        spaceInput.OnSpaceBar += HandleSpacebarClicked;
        
        //OverRide
        
        AudioManager audioManager = new AudioManager();
        audioManager.PlaySound("Explosion");
        audioManager.PlaySound("BG", 0.8f);

        Enemies enemies = new Enemies();
        enemies.Attack();

        Boss boss = new Boss();
        boss.Attack();

    }
    private void HandleEnemyDeath()
    {
        // Perform actions when the enemy is defeated
        Debug.Log("Enemy defeated!");
    }
    private void HandleSpacebarClicked()
    {
        // Jump logic for the object
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Object jumps!");
        // Perform the jump action here
    }
    
    
    public static void IncrementScore()
    {
        score = player.position.x;
    }
}
public static class StringExtensions
{
    // Extension method for the string class
    public static string CapitalizeLetter(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return str.ToUpper();
    }
}

// Static class defining the extension method

