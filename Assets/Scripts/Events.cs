using UnityEngine;

public class Events : MonoBehaviour
{
    public delegate void EnemyDeathDelegate();
    public event EnemyDeathDelegate OnEnemyDeath;
    public int health = 0;

    private void Update()
    {
        // Check if the enemy has been defeated
        if (IsDefeated())
        {
            // Invoke the enemy death event
            if (OnEnemyDeath != null)
                OnEnemyDeath.Invoke();

            // Destroy the enemy object
            Destroy(gameObject);
        }
    }

    private bool IsDefeated()
    {
        // Check if the enemy's health has reached zero
        // Return true if defeated, false otherwise
        return health <= 0;
    }
}



