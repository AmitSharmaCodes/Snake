using UnityEngine;
using System.Collections;

public class ResumePlay : MonoBehaviour {

   public  GameObject pauseOverlay;
   public SpriteRenderer smallPause;
    public void ClickedPlay()
    {
        Time.timeScale = 1.0f;
        GameState.gameState.paused = false;
        GameState.gameState.justUnPaused = true;
        pauseOverlay.SetActive(false);
        smallPause.enabled = true;
    }
}
