using UnityEngine;
using System.Collections;

public class ParticleSystemSpawner : MonoBehaviour {

    public static ParticleSystemSpawner explode;
    public ObjectPooler pool;
    public int numOfParticles = 50;
	// Use this for initialization
    void Awake() {
        
        if(explode == null)
            explode = this;
        else if(explode != this)
            Destroy(gameObject);
    }

    public void StartExplosion(Vector3 pos, Color c){

        ParticleSystem p = pool.GetPooledObject().GetComponent<ParticleSystem>();
        p.gameObject.SetActive(true);
      
        Color posCol = c;

        for(int i = 0; i < numOfParticles; i++){
            posCol.r += Random.Range(-0.15f, 0.15f);
            posCol.b += Random.Range(-0.15f, 0.15f);
            posCol.g += Random.Range(-0.15f, 0.15f);
            posCol.a = 1.0f;
            p.startColor = posCol;
            p.Emit(1);
        }

        p.transform.position = pos;

    }
}
