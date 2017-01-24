using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeDownToGame : MonoBehaviour {

    public Image blackSquare;
    public float speed = 1.0f;
    Color temp;
    public GameObject c;

    public bool done;
    void Start()
    {
        blackSquare.enabled = true;
        done = false;
        GameState.gameState.paused = true;
        temp = blackSquare.color;
        temp.a = 1;
        blackSquare.color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            temp.a -= Time.deltaTime * speed;
            if (temp.a <= 0)
            {
                temp.a = 0;
                done = true;
            }
            blackSquare.color = temp;
        }
        else
        {
            GameState.gameState.paused = false;
            Destroy(c);
        }
    }
}
