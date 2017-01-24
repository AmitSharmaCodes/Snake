using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButtonController : MonoBehaviour {
    public FadeUpFromMainMenu Fader;
    public void PlayGame()
    {
        if(Fader != null)
            Fader.enabled = true;
    }
}
