using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinbyPoints : MonoBehaviour {

    public int victoryNumber = 10;
    public SnakeHeadController[] snakes;
    public bool victory = false;
    static public WinbyPoints points;
	void Start () {
        if (points == null)
        {
            points = this;
            snakes = FindObjectsOfType<SnakeHeadController>();
        }
        else if(points != this)
            Destroy(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < snakes.Length; i++)
        {
            if(snakes[i].wasHit)
            {
                snakes[i].wasHit = false;
                snakes[i].removeSnakePart();
            }
            if (snakes [i].numberOfPieces + 1 >= victoryNumber)
            {
                victory = true;
                break;
            }
        }
        
        if (victory)
            SceneManager.LoadScene("PlayerSelect");
    }
}
