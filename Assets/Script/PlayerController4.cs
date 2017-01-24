using UnityEngine;
using System.Collections;

public class PlayerController4 : MonoBehaviour {

	// Use this for initialization
    public SnakeHeadController TopLeft;
    public SnakeHeadController BottomLeft;
    public SnakeHeadController TopRight;
    public SnakeHeadController BottomRight;
	
    int screenWidthHalf = Screen.width / 2;
    int screenHeightHalf = Screen.height / 2;

    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {


        if (!GameState.gameState.paused && !GameState.gameState.justUnPaused)
        {
            if(Input.touchCount > 0){
                for(int i = 0; i < Input.touchCount; i++) {
                    if(Input.GetTouch(i).phase == TouchPhase.Began){
                        if (Input.GetTouch(i).position.x < screenWidthHalf && Input.GetTouch(i).position.y < screenHeightHalf)
                        {
                            BottomLeft.switchDirection();
                        } else if (Input.GetTouch(i).position.x > screenWidthHalf && Input.GetTouch(i).position.y < screenHeightHalf)
                        {
                            BottomRight.switchDirection();
                        } else if (Input.GetTouch(i).position.x < screenWidthHalf && Input.GetTouch(i).position.y > screenHeightHalf)
                        {
                            TopLeft.switchDirection();
                        } else
                        {
                            TopRight.switchDirection();
                        }
                    }
                }
            }
        }
	
	}
}
