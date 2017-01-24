using UnityEngine;
using System.Collections;

public class ExplosionParticleScript : MonoBehaviour {

	// Use this for initialization
	public float fadeSpeed = 0.5f;
	public float shrinkSpeed = 0.25f;
    public Vector2 shrinkRange = new Vector2(1, -1);
	public float initialSize = 0.25f;
	public Vector3 rotateSpeed = new Vector3(0,0,5);
	public float Speed = 5.0f;
	//public Vector3 velocity = new Vecotor3();
	Vector3 velocity;
	SpriteRenderer rend;
	public Color c;
	float shrink, shrinkConstant;

	void OnEnable () {
		//	c = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),1);
		
		if(rend == null)
			rend = gameObject.GetComponent<SpriteRenderer>();
		//rend.color = c;
		Vector3 vel = GetRandomDirection() * Random.Range(0.0f, 2.0f);

		velocity.x = vel.x;
		velocity.y = vel.y;
		//rend.color = c;
		shrink = initialSize;
		shrinkConstant = Random.Range(shrinkRange.x, shrinkRange.y);
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(rotateSpeed);
		UpdateScale();
		UpdateColor();
		UpdatePosition();
	}

	Vector3 GetRandomDirection(){
		float direction = Random.Range (0.0f, 6.2831f);
		return new Vector3 (Mathf.Cos (direction), Mathf.Sin (direction), 0);

	}

	void UpdatePosition(){
		gameObject.transform.position += velocity * Time.deltaTime * Speed; 
	}

	void UpdateColor()
	{
		//c.a -= Time.deltaTime * fadeSpeed;
		if(c.a < 0)
		{
			c.a = 0;
			gameObject.SetActive(false);
		}
		//rend.color = c;
	}
	void UpdateScale(){
		shrink -= Time.deltaTime * shrinkSpeed * shrinkConstant; 
		Vector3 scale = gameObject.transform.localScale;
		scale.x = shrink;
		scale.y = shrink;
		scale.z = shrink;
		
		gameObject.transform.localScale = scale;
	}
}
