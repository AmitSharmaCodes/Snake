using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FadeInGameOver : MonoBehaviour {

    // Use this for initialization
    public Image[] images;
    public Text text;
    public Text highscore;
    public float speed;
    float currentAlpha;
    public float maxAlpha = .4f;
    bool done;

	void OnEnable() {
        highscore.text = PlayerPrefs.GetInt("currentScore").ToString();
        done = false;
        currentAlpha = 0;
        foreach (Image i in images)
        {
            Color temp = i.color;
            temp.a = 0;
            i.color = temp;
        }
        Color t = text.color;
        t.a = 0;
        text.color = t;
        highscore.color = t;

	
	}
	
	// Update is called once per frame
	void Update () {
        if (!done)
        {
            currentAlpha += Time.deltaTime * speed;
            if (currentAlpha > maxAlpha)
            {
                currentAlpha = maxAlpha;
                done = true;
            }
            foreach (Image i in images)
            {
                Color temp = i.color;
                temp.a = currentAlpha;
                i.color = temp;
            }
            Color t = text.color;
            t.a = currentAlpha;
            text.color = t;
            highscore.color = t;
        }
    }
}
