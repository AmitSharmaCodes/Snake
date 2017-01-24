using UnityEngine;
using System.Collections;

public class SnakeDeath : MonoBehaviour {

    // Use this for initialization
    SnakeHeadController snake;
    public SnakePartController current;
    bool done = false;
    Vector3 position; 
	void OnEnable() {
        done = false;
        snake = FindObjectOfType<SnakeHeadController>();
        position = snake.transform.position;
        current = snake.nextPiece;
	}
	
	// Update is called once per frame
	void Update () {
        if (!done)
        {
            if (current.gameObject.transform.position == position)
            {
                SnakePartController previous = current;
                if (current.pieceBehind != null)
                    current = current.pieceBehind;
                else
                {
                    snake.gameObject.SetActive(false);
                    ParticleSystemSpawner.explode.StartExplosion(snake.gameObject.transform.position, snake.gameObject.GetComponent<SpriteRenderer>().color);
                    done = true;
                }
                Color temp = Color.black;
                temp.a = 0;
                previous.gameObject.GetComponent<SpriteRenderer>().color = temp;
                
            }
        }
	
	}
}
