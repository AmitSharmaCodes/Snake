using UnityEngine;
using System.Collections;

public class OssBetweenTwoAlpha : MonoBehaviour {

	// Use this for initialization
    public float min;
    public float max;
    public float speed;

    public SpriteRenderer rend;
    Color col;
    float direction;
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();
        col = rend.color;
        direction = 1;
    
	}
	
	// Update is called once per frame
	void Update () {
        col.a += direction * speed * Time.deltaTime;

        if (col.a > max)
        {
            col.a = max;
            direction *= -1;
        }
        else if(col.a < min)
        {
            col.a = min;
            direction *= -1;
        }

        rend.color = col;
	
	}
}
