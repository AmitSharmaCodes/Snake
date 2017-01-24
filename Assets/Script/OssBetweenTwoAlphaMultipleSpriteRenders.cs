using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OssBetweenTwoAlphaMultipleSpriteRenders : MonoBehaviour {

	// Use this for initialization
    public float min;
    public float max;
    public float speed;

    public SpriteRenderer[] rend;
    public Text[] text;
    float alpha;
    float direction;

    Color temp;
	void Start () {
        direction = 1;
        alpha = rend[0].color.a;
    
	}
	
	// Update is called once per frame
	void Update () {

        alpha += direction * speed * Time.deltaTime;

        if (alpha > max)
        {
            alpha = max;
            direction *= -1;
        }
        else if(alpha < min)
        {
            alpha = min;
            direction *= -1;
        }

        foreach (SpriteRenderer r in rend)
        {
            temp = r.color;
            temp.a = alpha;
            r.color = temp;
        }
        foreach(Text t in text)
        {
            temp = t.color;
            temp.a = alpha;
            t.color = temp;
        }
	
	}
}
