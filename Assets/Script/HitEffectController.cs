using UnityEngine;
using System.Collections;

public class HitEffectController : MonoBehaviour {

	// Use this for initialization
    public float hitTime;
    public SpriteRenderer sprite;
    public GameObject snake;

    float currentTime;
    float inverseHitTime;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = snake.transform.position;
        currentTime += Time.deltaTime;
        if (currentTime > hitTime)
            gameObject.SetActive(false);
        else
        {
            Color temp = sprite.color;
            temp.a = (hitTime - currentTime) * inverseHitTime;
            sprite.color = temp;
        }
	}
    void OnEnable(){
        currentTime = 0;
        inverseHitTime = 1.0f / hitTime;
    }
}
