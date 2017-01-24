using UnityEngine;
using System.Collections;

public class TargetSpawnerController : MonoBehaviour {

	// Use this for initialization
	public ObjectPooler targets;
    public Vector2 minBound;
    public Vector2 maxBound;
    public int targetCount = 0;
    public int maxTargets = 3;
    public float delayBetweenTargets = 0.2f;
    static public TargetSpawnerController target;

    float currentTime;
	void Start () {
        currentTime = 0;
	
	}
    void Awake() {
        
        if(target == null)
            target = this;
        else if(target != this)
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        currentTime += Time.deltaTime;
        if (targetCount < maxTargets && currentTime > delayBetweenTargets)
        {
            CreateTarget();
            currentTime = 0;
        }

	}

    void CreateTarget(){
        GameObject obj = targets.GetPooledObject();
        float x = 0;
        float y = 0;
        while (x == 0 && y == 0)
        {
             x = Random.Range(minBound.x, maxBound.x);
            float remainder = x % 2.5f;
            x -= remainder;


             y = Random.Range(minBound.y, maxBound.y);
            remainder = y % 2.2f;
            y -= remainder;
            if (y % 4.4f != 0)
                x += 1.25f;

        }

        obj.transform.position = new Vector3(x, y, -0.1f);
        //Vector3 pos = new Vector3(Random.Range(minBound.x, maxBound.x), Random.Range(minBound.y, maxBound.y));

        obj.SetActive(true);
        targetCount++;
    }
}
