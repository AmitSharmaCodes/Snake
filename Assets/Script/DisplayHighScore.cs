using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DisplayHighScore : MonoBehaviour {

    public Text[] texts;
	// Use this for initialization
	void Start () {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        Debug.Log(highScore);
        int hundreds = highScore / 100;
        highScore %= 100;
        int tens = highScore / 10;
        highScore %= 10;
        int ones = highScore;

        texts[0].text = hundreds.ToString();
        texts[1].text = tens.ToString();
        texts[2].text = ones.ToString();
	}
}
