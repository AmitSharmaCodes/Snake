using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {

    
    
    // Use this for initialization
    public SnakeHeadController snake;
    
    

    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {

        if(Input.touchCount > 0)
            if(Input.GetTouch(0).phase == TouchPhase.Began)
                snake.switchDirection(); 
      //  if (!GameState.gameState.paused && !GameState.gameState.justUnPaused)
       //     if (Input.GetMouseButtonDown(0))
        //            snake.switchDirection();  
    }
}