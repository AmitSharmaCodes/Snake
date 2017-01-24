using UnityEngine;
using System.Collections;

public class GlowPiece : MonoBehaviour {

	// Use this for initialization
    public SnakePartController currentPiece;
    public float durationOnPiece = 0.1f;
    float timer;
	void Start () {
	
	}
    void OnEnable () {
        timer = 0.0f;
    }
    void OnDisable(){
        currentPiece = null;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = currentPiece.transform.position;
        timer += Time.deltaTime;
        if (timer > durationOnPiece)
        {
            timer = 0;
            if(currentPiece.pieceBehind != null && currentPiece.pieceBehind.gameObject.activeSelf)
                currentPiece = currentPiece.pieceBehind;
            else
                gameObject.SetActive(false);
        }
	}
}
