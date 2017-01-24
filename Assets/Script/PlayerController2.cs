using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

    
    // Use this for initialization
    public SnakeHeadController left;
    public SnakeHeadController right;
    
    
    int firstHalf = Screen.width / 2;
    
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        if (!GameState.gameState.paused && !GameState.gameState.justUnPaused)
        {
            if(Input.touchCount > 0){
                for(int i = 0; i < Input.touchCount; i++) {
                    if(Input.GetTouch(i).phase == TouchPhase.Began){
                        if (Input.GetTouch(i).position.x < firstHalf)
                            left.switchDirection();
                        else
                            right.switchDirection();
                    }
                }
            }
        }
    }
}