using UnityEngine;
using System.Collections;

public class MParticle{

	// Use this for initialization
    public float fadeSpeed = 1.0f;
    public float shrinkSpeed = 0.5f;
    public Vector2 shrinkRange = new Vector2(0, 1);
    public float initialSize = 1.0f;
    public Vector3 rotateSpeed = new Vector3(0,0,5);
    public float Speed = 5.0f;
    //public Vector3 velocity = new Vecotor3();
    Vector3 velocity;
    public Color color = Color.white;

    float shrinkConstant;
    public float size;

    public bool isActive;
    public Vector3 position;

    public void OnEnable (Color32 col, Vector3 pos) {
        //  c = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),1);
        isActive = true;
        color = col;
        position = pos;

        Vector3 vel = GetRandomDirection() * Random.Range(0.0f, 2.0f);
        
        velocity.x = vel.x;
        velocity.y = vel.y;
        //rend.color = c;
        size = initialSize;
        shrinkConstant = Random.Range(shrinkRange.x, shrinkRange.y);
        
    }
    
    // Update is called once per frame
    public void Update () {
       // gameObject.transform.Rotate(rotateSpeed); add rotation back in
        if (isActive) {
            UpdateScale();
            UpdateColor();
            UpdatePosition();
        }
    }
    
    Vector3 GetRandomDirection(){
        float direction = Random.Range (0.0f, 6.2831f);
        return new Vector3 (Mathf.Cos (direction), Mathf.Sin (direction), 0);
        
    }
    
    void UpdatePosition(){
        position += velocity * Time.deltaTime * Speed; 
    }
    
    void UpdateColor()
    {
        color.a -= Time.deltaTime * fadeSpeed;
        if(color.a < 0)
        {
            color.a = 0;
            isActive = false;
            ParSys.particleNumberChanged = true;
            ParSys.particleCount--;
        }
    }
    void UpdateScale(){
        size -= Time.deltaTime * shrinkSpeed * shrinkConstant; 

    }
}
