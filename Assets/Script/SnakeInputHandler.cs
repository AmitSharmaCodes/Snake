using UnityEngine;
using System.Collections;

public class SnakeInputHandler : MonoBehaviour {
    public SnakeController snake;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            snake.switchDirection();
        }

        /*
         * if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            snake.switchDirection();
        }
        if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            snake.AddLink();
        }
        */
	
	}
}
