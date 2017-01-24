using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	// Use this for initialization
     public bool paused = false;
     public bool justUnPaused = false;
    public bool gameOver = false;
    static public GameState gameState;

	void Start () {
        if (gameState == null)
            gameState = this;
        else if(gameState != this)
            Destroy(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
