using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LerpBetweenColors : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer[] BackgroundHexs;
    public SpriteRenderer playHex;
    public Image[] buttonHexes;
    public Text[] titleText;
    public Text[] buttonText;
    private Color frontColorButton;
    private Color frontColorTitle;
    private Color frontColorButtonText;
    private Color backColor;
    public float primaryColorVariance = .5f;
    public float secondaryColorVariance = .1f;
    public float varianceInBackground = .1f;
    public float varianceInTitle = .1f;

    void Start () {
        backColor = new Color(Random.Range(.4f, .9f), Random.Range(.4f, .9f), Random.Range(.4f, .9f));
        frontColorButton = backColor;
        frontColorButton.a = .396f;
        frontColorButtonText = backColor;
        frontColorButtonText.a = .596f;
        frontColorTitle = backColor;

        if (backColor.r >= backColor.g && backColor.r >= backColor.b)
        {
            frontColorTitle.r += Random.Range(0, primaryColorVariance);
            frontColorTitle.g += Random.Range(-secondaryColorVariance, secondaryColorVariance);
            frontColorTitle.b += Random.Range(-secondaryColorVariance, secondaryColorVariance);
        }
        else if (backColor.g >= backColor.r && backColor.g >= backColor.b)
        {
            frontColorTitle.r += Random.Range(-secondaryColorVariance, secondaryColorVariance);
            frontColorTitle.g += Random.Range(0, primaryColorVariance);
            frontColorTitle.b += Random.Range(-secondaryColorVariance, secondaryColorVariance);
        }
        else
        {
            frontColorTitle.r += Random.Range(-secondaryColorVariance, secondaryColorVariance);
            frontColorTitle.g += Random.Range(-secondaryColorVariance, secondaryColorVariance);
            frontColorTitle.b += Random.Range(0, primaryColorVariance);
        }

        if(playHex != null)
            playHex.color = frontColorButton;

        Color temp;
        foreach (SpriteRenderer r in BackgroundHexs)
        {
            temp = backColor;
            temp.r += Random.Range(-varianceInBackground, varianceInBackground);
            temp.g += Random.Range(-varianceInBackground, varianceInBackground);
            temp.b += Random.Range(-varianceInBackground, varianceInBackground);
            r.color = temp;
        }
        foreach (Image i in buttonHexes)
            i.color = frontColorButton;
        foreach (Text t in titleText)
        {
            temp = frontColorTitle;
            temp.r += Random.Range(-varianceInTitle, varianceInTitle);
            temp.g += Random.Range(-varianceInTitle, varianceInTitle);
            temp.b += Random.Range(-varianceInTitle, varianceInTitle);
            t.color = temp;
        }
        foreach (Text t in buttonText)
            t.color = frontColorButtonText;


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
