using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ToMainMenu : MonoBehaviour {

    public GameObject Fader;

    public void ClickedHome()
    {
        Instantiate(Fader);
        Time.timeScale = 1.0f;
        //GameState.gameState.paused = false;
        //GameState.gameState.justUnPaused = true;
        //SceneManager.LoadScene("PlayerSelect");
        //cam.cullingMask = 1;
        //SceneManager.UnloadScene("Pause");
    }
}
