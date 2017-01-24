using UnityEngine;
using System.Collections;

public class TargetGlowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnEnable () {
        GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
