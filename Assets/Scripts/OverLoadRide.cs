using UnityEngine;
public class AudioManager
    {
        public void PlaySound(string name)
        {
            Debug.Log("Playing sound" + name);
        }

        public void PlaySound(string name, float volume)
        {
            Debug.Log("Playing sound" + name +" With Volume "+ volume);
        }
    }


    public class Enemies
    {
        public virtual void Attack()
        {
            Debug.Log("Enemy attacks");
        }
    }

    public class Boss : Enemies
    {
        public override void Attack()
        {
            //special behaviour for boss enemy
            Debug.Log("Boss performs a powerful attack");
        }
    }
