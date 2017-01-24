using UnityEngine;
using System.Collections;

public class FadeDownSpriteRenderer : MonoBehaviour {

    public SpriteRenderer image;
    public float lengthOfFade = 1.0f;
    private float speed;
    Color temp;
    private bool done;

    // Use this for initialization
    void Start()
    {
        temp = image.color;
        speed = (1 - image.color.a) / lengthOfFade;
        done = false;
        Debug.Log(image.color);


    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            temp = image.color;
            temp.a += Time.deltaTime * speed;
            if (temp.a > 1.0f)
            {
                temp.a = 1.0f;
                done = true;
            }
            image.color = temp;
        }

    }

    public bool Done()
    {
        return done;
    }
}
