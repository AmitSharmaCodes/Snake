using UnityEngine;
using System.Collections;

public class SpinHexRandomly : MonoBehaviour {

    // Use this for initialization
    public float spinDelay = .1f;
    float currentDelay;
    int aniLength;
    public Animator[] anis;

    void Start()
    {
        currentDelay = 0;
        aniLength = anis.Length;
    }
	// Update is called once per frame
	void Update () {
        currentDelay += Time.deltaTime;
        if (currentDelay >= spinDelay)
        {
            anis[Random.Range(0, aniLength - 1)].SetBool("Spin", true);
            currentDelay = 0;
        }
	}
}
