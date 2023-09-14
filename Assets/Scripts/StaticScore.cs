using UnityEngine;

public class StaticScore : MonoBehaviour
{
    //public Text scoreText;
    public Transform player;
    public Vector3 previousPosition;

   // private GameManager gameManager;
    public void Start()
    {
     //gameManager = GetComponent<GameManager>();
     player = GameObject.FindGameObjectWithTag("Player").transform;
     previousPosition = player.position;
    }

    void FixedUpdate()
    {
        if (player.position != previousPosition)
        { 
            GameManager.IncrementScore();
        //scoreText.text = "Score:" + GameManager.score.ToString("0");
        
            Debug.Log(GameManager.score.ToString("0"));
            previousPosition = player.position;
        }
    }
}
