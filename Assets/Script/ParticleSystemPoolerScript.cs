using UnityEngine;
using System.Collections;

public class ParticleSystemPoolerScript : MonoBehaviour {

	// Use this for initialization
    public ParticleSystem p;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!p.IsAlive())
            gameObject.SetActive(false);
	
	}
}
