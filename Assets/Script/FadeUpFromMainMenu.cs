using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeUpFromMainMenu : MonoBehaviour {

    public Image blackSquare;
    public float speed = 1.0f;
    Color temp;

    public bool done;
	void OnEnable() {
        blackSquare.gameObject.SetActive(true);
        done = false;
        temp = blackSquare.color;
        temp.a = 0;
        blackSquare.color = temp;
	}
	
	// Update is called once per frame
	void Update () {
        if (!done)
        {
            temp.a += Time.deltaTime * speed;
            if (temp.a >= 1.0f)
            {
                temp.a = 1;
                done = true;
            }
            blackSquare.color = temp;
        }
        else
        {
            switch (MainMenuController.Instance.getPlayerNum())
            {
                case 1:
                    SceneManager.LoadScene("1PlayerMode");
                    break;
                case 2:
                    SceneManager.LoadScene("2PlayerMode");
                    break;
                case 3:
                    SceneManager.LoadScene("3PlayerMode");
                    break;
                case 4:
                    SceneManager.LoadScene("4PlayerMode");
                    break;
            }
        }
	}
}
