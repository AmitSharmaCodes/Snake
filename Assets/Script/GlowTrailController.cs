using UnityEngine;
using System.Collections;

public class GlowTrailController : MonoBehaviour {

	// Use this for initialization
    public SnakeHeadController snakeHead;
    public ObjectPooler glowPiece;

    SpriteRenderer rend;

	void Start () {
        rend = snakeHead.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addGlowPiece()
    {
       GameObject g = glowPiece.GetPooledObject();
       SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
       sr.sprite = rend.sprite;
       sr.color = rend.color;
       GlowPiece gp = g.GetComponent<GlowPiece>();
       gp.currentPiece = snakeHead.nextPiece;
        g.transform.position = gp.currentPiece.gameObject.transform.position;
       g.SetActive(true);

    }
}
