using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	// Use this for initialization
    SnakeController snake;
    public float radius = .375f;
	
    float collisionDistanceSquared;
    void Start()
    {
        snake = FindObjectOfType<SnakeController>();
        collisionDistanceSquared = (radius + snake.radius) * (radius + snake.radius);

    }
    void OnEnable(){
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f), .8f); 
    }

    void Update()
    {
        CollisionWithSnake();
    }

    void CollisionWithSnake(){

            float squaredDis = Vector3.SqrMagnitude(transform.position - snake.transform.position);
            if (squaredDis < collisionDistanceSquared)
            {
                HitSnake(snake);
            }

        //the overlap links also have to have collision
        for (int i = 0; i < 3; i++)
        {
            if (snake.overlapLinks[i].activeSelf)
            {
                squaredDis = Vector3.SqrMagnitude(transform.position - snake.overlapLinks[i].transform.position);
                if (squaredDis < collisionDistanceSquared)
                {
                    Debug.Log("OVERLAP HIT");
                    HitSnake(snake);
                }
            }
        }
    }

    void HitSnake(SnakeController snake){
        snake.AddLink();
        TargetSpawnerController.target.targetCount--;
      
        ParticleSystemSpawner.explode.StartExplosion(transform.position, GetComponent<SpriteRenderer>().color);
        HexGrid.hexGrid.Turn();
        //ParSys.system.StartExplosion(transform.position, GetComponent<SpriteRenderer>().color); 
        gameObject.SetActive(false);
       
    }
}
