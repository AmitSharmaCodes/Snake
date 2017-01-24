using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {

	// Use this for initialization
    static public BubbleSpawner bubble;
    public ObjectPooler bubbles;
	void Start () {
	
	}
    void Awake() {
        
        if(bubble == null)
            bubble = this;
        else if(bubble != this)
            Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnBubble(Vector3 pos)
    {
        GameObject bubble = bubbles.GetPooledObject();
        bubble.transform.position = pos;
        bubble.SetActive(true);
    }
}
