using UnityEngine;
using System.Collections;

public class PlayerController3 : MonoBehaviour {

    // Use this for initialization
    public SnakeHeadController left;
    public SnakeHeadController middle;
    public SnakeHeadController right;

    
    int firstThird = Screen.width / 3;
    int secondThird = Screen.width * 2 / 3;
    
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {

        if (!GameState.gameState.paused && !GameState.gameState.justUnPaused)
        {
            if(Input.touchCount > 0){
                for(int i = 0; i < Input.touchCount; i++) {
                    if(Input.GetTouch(i).phase == TouchPhase.Began){
                        if (Input.GetTouch(i).position.x < firstThird)
                        {
                            left.switchDirection();
                        } else if (Input.GetTouch(i).position.x < secondThird)
                        {
                            middle.switchDirection();
                        } else
                        {
                            right.switchDirection();
                        }
                    }
                }
            }
        }
    }
}