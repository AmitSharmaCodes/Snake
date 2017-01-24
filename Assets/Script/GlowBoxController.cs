using UnityEngine;
using System.Collections;

public class GlowBoxController : MonoBehaviour {

	// Use this for initialization
    Animator ani;
    int lightHash = Animator.StringToHash("Light");
    int growHash = Animator.StringToHash("GrowAndSpin");
    Color c;
    public float radius = 1.27f;
    public float left, right, bottom, top;
    float snakeSquared;
    bool hit, enter;

    SnakeHeadController snake;

	void Start () {
        enter = hit = false;

        Vector3 pos = transform.position;
        left = pos.x - radius;
        right = pos.x + radius;
        top = pos.y + radius;
        bottom = pos.y - radius;

        snake = FindObjectOfType<SnakeHeadController>();
        snakeSquared = snake.radius * snake.radius;
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        CollisionWithSnake();
     //   CollisionWithBubbles();
	}
    /*
    void CollisionWithBubbles()
    {
        foreach (GameObject g in bubbles.pooledObjects)
        {
            if(g.activeSelf)
            {
              float bubbleRadius = g.GetComponent<TargetBubbleController>().radius;
                bubbleRadius = bubbleRadius * bubbleRadius; //bubbleradius squared

                Vector3 point = g.transform.position;
                
                if (point.x > right)
                    point.x = right;
                else if (point.x < left)
                    point.x = left;
                
                if (point.y > top)
                    point.y = top;
                else if (point.y < bottom)
                    point.y = bottom;
                
                float squaredDistance = Vector3.SqrMagnitude(point - g.transform.position);
                if (squaredDistance < bubbleRadius)
                    HitBubble();
                else
                    hitBubble = false;


            }
        }

    }*/
    void CollisionWithSnake(){
        Vector3 point = snake.transform.position;

        if (point.x > right)
            point.x = right;
        else if (point.x < left)
            point.x = left;

        if (point.y > top)
            point.y = top;
        else if (point.y < bottom)
            point.y = bottom;

        float squaredDistance = Vector3.SqrMagnitude(point - snake.transform.position);
        if (squaredDistance < snakeSquared)
            HitSnake();
        else
            hit = false;

    }

  /*  void HitBubble(){
        if (!hitBubble)
            enterBubble = true;
        else
            enterBubble = false;
        hitBubble = true;
        
        if (enterBubble)
            ani.SetTrigger(growHash);
        //     snake.hitSnakePiece();
        //Debug.Log("HIT SQUARE");
    }*/
    public void hitBubble()
    {
        ani.SetTrigger(growHash);
    }

    void HitSnake(){
        if (!hit)
            enter = true;
        else
            enter = false;
        hit = true;

        if (enter)
            ani.SetTrigger(lightHash);
   //     snake.hitSnakePiece();
        //Debug.Log("HIT SQUARE");
    }

   // void OnTriggerEnter2D(Collider2D other){
    //    Debug.Log("DO SHIT");
      //  if (other.tag == "SnakeHead")
          //  ani.SetTrigger(lightHash);
     //   else if (other.tag == "Bubble")
           // ani.SetTrigger(growHash);
   // }
}
