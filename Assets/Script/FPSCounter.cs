using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour {

	// Use this for initialization
    int count;
    float currentTime;
    public GUIText gtext;
	void Start () {
        currentTime = 0;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        count++;
        if (currentTime > 1.0f)
        {
            gtext.text = count.ToString();
            currentTime = 0;
            count = 0;
        }
	
	}
}
