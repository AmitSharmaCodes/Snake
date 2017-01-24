using UnityEngine;
using System.Collections;

public class SquareGrid : MonoBehaviour {

	// Use this for initialization
    static public SquareGrid box;
    public GlowBoxController[] boxes;

	void Start () {
        boxes = FindObjectsOfType<GlowBoxController>();
	}

    void Awake() {
        
        if(box == null)
            box = this;  
        else if(box != this)
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
