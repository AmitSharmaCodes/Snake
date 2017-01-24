using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour {

	public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
