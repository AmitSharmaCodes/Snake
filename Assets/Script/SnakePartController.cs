using UnityEngine;
using System.Collections;

public class SnakePartController : MonoBehaviour {

	// Use this for initialization
    public RecordPosTime pieceInFront;
    public SnakePartController pieceBehind;
    public float followTime = 1.0f;
    float sleepTimer;

    public float radius = 0.75f;
    public SnakeHeadController head;
                                            
    float collisionDistanceSquared;

    public bool isSafe = false;
   public bool firstMove, minTime;

    private Vector2 currentpos;
    private float followDistanceSquared;

	void Start () {
        followTime = 1.25f/ head.speed;
        sleepTimer = 0;
        firstMove = minTime = false;
        collisionDistanceSquared = (radius + head.radius) * (radius + head.radius);
        followDistanceSquared = (radius * radius) - (radius * .25f);
        followDistanceSquared *= followDistanceSquared;
	}

    void OnDisable()
    {
//        Debug.Log("OnDisable");
        sleepTimer = 0;
        firstMove = minTime = false;
        pieceBehind = null;
        pieceInFront = null;
        head = null;
        isSafe = false;
    }
   
	
	// Update is called once per frame
	void Update () {
       if (!GameState.gameState.paused)
        {

            pieceInFront.asleep = false;
            sleepTimer += Time.deltaTime;
             if (sleepTimer >= followTime)
            {
                if (!firstMove)
                {
                    firstMove = true;
                    if (KeepTime())
                        minTime = true;
                   ThrowAway();
                } else
                {
                    if (minTime)
                    {
                        if (pieceInFront.timePos.Count > 0)
                        {
                            TimePos obj = pieceInFront.timePos.Dequeue();
                            transform.position = obj.pos;
                            if (!isSafe)
                                CollisionWithSnake();
                        }
                    } else
                    {
                        if (KeepTime())
                        {
                            minTime = true;
                            ThrowAway();
                       }
                    }
                }

            }
        }
    }
    bool KeepTime(){
        if (pieceInFront.timePos.Count > 0)
            if((Time.time - pieceInFront.timePos.Peek().time) > followTime)
                return true;
        return false;
    }

    void ThrowAway()
    {
        while(pieceInFront.timePos.Count > 0)
        {
            if((Time.time - pieceInFront.timePos.Peek().time) > followTime)
                transform.position = pieceInFront.timePos.Dequeue().pos;
            else
                break;
        }
    }

    void CollisionWithSnake(){
        float squaredDis = Vector3.SqrMagnitude(transform.position - head.transform.position);
        if (squaredDis < collisionDistanceSquared)
        {
            HitSnake();
        }
    }

    void HitSnake(){
        head.hitSnakePiece();
    }
}
