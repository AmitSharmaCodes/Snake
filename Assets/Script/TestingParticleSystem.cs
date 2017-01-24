using UnityEngine;
using System.Collections;

public class TestingParticleSystem : MonoBehaviour {

	// Use this for initialization
   // Camera cam;
   // public ObjectPooler pool;
    HexController hex;
	void Start () {
      //  cam = FindObjectOfType<Camera>();
        hex = FindObjectOfType < HexController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){

            hex.Turn();
           /* ParticleSystem p = pool.GetPooledObject().GetComponent<ParticleSystem>();
            Debug.Log(p);
            p.gameObject.SetActive(true);
            Color posCol = new Color(Random.Range(.2f, .9f), Random.Range(.2f, .9f), Random.Range(.2f, .9f));
            for(int i = 0; i < 100; i++){
                posCol.r += Random.Range(-0.15f, 0.15f);
                posCol.b += Random.Range(-0.15f, 0.15f);
                posCol.g += Random.Range(-0.15f, 0.15f);
                p.startColor = posCol;
                p.Emit(1);
            }

            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            p.transform.position = pos;
          //  for(int i = 0; i < 100; i++){
				//
         //       p.Emit(pos, GetRandomDirection() * Random.Range(5,30), 1,1,new Color32(255,255,255,255));
        //    }
           // ParSys.system.StartExplosion(pos, 
         */                             //   new Color(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f)));
        }
	
	}

}
