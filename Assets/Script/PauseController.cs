using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    Camera cam;
    public SpriteRenderer smallPause;
    public GameObject pauseOverLay;
	void Start () {
        cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        GameState.gameState.justUnPaused = false;
        if (Input.touchCount > 0) //if a touch
        {
            for (int i = 0; i < Input.touchCount; i++)
            { //go through every touch
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                { //only on the first touch matters, like the down motion, I dont care if you have been touching the screen
                    if (!GameState.gameState.paused) //if game is paused and someone touched the screen, resume

                    {
                        Vector3 world = cam.ScreenToWorldPoint(Input.GetTouch(i).position); //convert from screenn to world space
                        if (GetComponent<Collider2D>().OverlapPoint(world))
                        { // check overlap, if you pressed pause button
                            Time.timeScale = 0; //pauses time
                            GameState.gameState.paused = true;
                            pauseOverLay.SetActive(true); //put up overlay
                            //cam.cullingMask = 1 << 8;
                            //SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
                            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Pause"));
                            //Debug.Log(SceneManager.GetActiveScene().name);
                            smallPause.enabled = false; //take away tiny button
                    
                        }
                    }
                    break;
                }
            }
        }
    }
}


/*                    {
                        Time.timeScale = 1.0f;
                        GameState.gameState.paused = false;
                        GameState.gameState.justUnPaused = true;
                        pauseOverLay.SetActive(false);
                        smallPause.enabled = true;
                        //cam.cullingMask = 1;
                        //SceneManager.UnloadScene("Pause");
                    
                    } else //not paused, see if someone hit the pause button
*/