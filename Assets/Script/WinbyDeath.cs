using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinbyDeath : MonoBehaviour {

    public SnakeHeadController[] snakes;
    public bool gameOver = false;
    static public WinbyDeath death;
    int snakeNum;
    void Start () {
        if (death == null)
        {
            death = this;
            snakes = FindObjectsOfType<SnakeHeadController>();
            snakeNum = snakes.Length;
        }
        else if(death != this)
            Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update () {
        for (int i = 0; i < snakes.Length; i++)
        {
            if(snakes[i].wasHit)
            {
                snakes[i].wasHit = false;
                snakes[i].killSnake();
                snakeNum--;

              //  gameOver = true;
            }
        }

        if(snakeNum == 1 || snakeNum == 0)
            gameOver = true;
        
        if (gameOver)
        {

            // Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("PlayerSelect");
        }
    }
}