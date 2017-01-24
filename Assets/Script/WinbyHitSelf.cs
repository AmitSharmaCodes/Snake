using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinbyHitSelf : MonoBehaviour {

    public SnakeController snake;
    public bool gameOver = false;
    static public WinbyHitSelf death;
    public GameObject gameOverOverLay;
    public GameObject pauseButton;
    void Start () {
        if (death == null)
        {
            death = this;

        }
        else if(death != this)
            Destroy(gameObject);
        
    }
    
    // Update is called once per frame
    void Update () {
        if(snake.wasHit)
        {
            snake.wasHit = false;
            gameOver = true;
            GameState.gameState.gameOver = true; 
                //  gameOver = true;
        }

        if (gameOver)
        {
 
            PlayerPrefs.SetInt("currentScore", snake.size());
            if (snake.size() > PlayerPrefs.GetInt("highscore", 0))
            {
                Debug.Log(snake.size());
                PlayerPrefs.SetInt("highscore", snake.size());
                PlayerPrefs.Save();
            }
            gameOverOverLay.SetActive(true);
            pauseButton.SetActive(false);
            snake.speed = 0;


        }
    }
}
