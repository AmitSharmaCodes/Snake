using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeDoneToMainMenu : MonoBehaviour {

    // Use this for initialization
    FadeDownSpriteRenderer fader;
   
	void Start () {
        fader = FindObjectOfType<FadeDownSpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (fader.Done())
        {
             GameState.gameState.paused = false;
            GameState.gameState.justUnPaused = true;
            SceneManager.LoadScene("PlayerSelect");
        }

    }
}
