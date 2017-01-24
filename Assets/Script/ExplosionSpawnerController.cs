using UnityEngine;
using System.Collections;

public class ExplosionSpawnerController : MonoBehaviour {

	// Use this for initialization
	public ObjectPooler particles;
	public int numOfParticles = 50;
	public bool colored;
    public static ExplosionSpawnerController explode;
	//void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {
	//}
    void Awake() {
        
        if(explode == null)
            explode = this;
        else if(explode != this)
            Destroy(gameObject);
    }

	public void StartExplosion(GameObject pos){
		Color posCol = Color.black;

		if(colored)
			posCol = pos.GetComponent<SpriteRenderer> ().color;

		for(int i = 0; i < numOfParticles; i++) {
			GameObject obj = particles.GetPooledObject();
			obj.transform.position = pos.transform.position;
			if(colored){
				posCol.r += Random.Range(-0.15f, 0.15f);
				posCol.b += Random.Range(-0.15f, 0.15f);
				posCol.g += Random.Range(-0.15f, 0.15f);
			}

			obj.GetComponent<ExplosionParticleScript>().c = posCol;
			obj.SetActive(true);
		}
	}
}
