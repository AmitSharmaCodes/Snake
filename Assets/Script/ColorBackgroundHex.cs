using UnityEngine;
using System.Collections;

public class ColorBackgroundHex : MonoBehaviour {

    public SpriteRenderer[] BackgroundHexs;
    public Color backColor;
    public float varianceInBackground = .1f;

    void Start () {
        Color temp;
        foreach (SpriteRenderer r in BackgroundHexs)
        {
            temp = backColor;
            temp.r += Random.Range(-varianceInBackground, varianceInBackground);
            temp.g += Random.Range(-varianceInBackground, varianceInBackground);
            temp.b += Random.Range(-varianceInBackground, varianceInBackground);
            r.color = temp;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
