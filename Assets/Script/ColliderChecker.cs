using UnityEngine;
using System.Collections;

public class ColliderChecker : MonoBehaviour {

	// Use this for initialization
    public SnakeController snake;

    float snakeHexRadiusSquared;
    float snakeRadius;
	void Start () {
        snakeRadius = snake.radius;
        snakeHexRadiusSquared  = (snake.radius + HexGrid.hexGrid.hexes[0].radius) * (snake.radius + HexGrid.hexGrid.hexes[0].radius);
	}
	
	// Update is called once per frame
	void Update () {
        HexSnakeCollision();
        //SnakeSnakeCollision();
	}

    void HexSnakeCollision(){
        bool above = snake.transform.position.y + snakeRadius > 0;
        bool below = snake.transform.position.y - snakeRadius < 0;
        bool left = snake.transform.position.x - snakeRadius < 0;
        bool right = snake.transform.position.x + snakeRadius > 0;

        if(above && left)
        {
           
            foreach(HexController h in HexGrid.hexGrid.upperLeft)
            {
                float dis = Vector3.SqrMagnitude(snake.transform.position
                                                - h.transform.position);
                if (dis <= snakeHexRadiusSquared)
                {
                    h.LightUp();
                }
            }
        }

        if (above && right)
        {
          
            foreach (HexController h in HexGrid.hexGrid.upperRight)
            {
                float dis = Vector3.SqrMagnitude(snake.transform.position
                                                - h.transform.position);
                if (dis <= snakeHexRadiusSquared)
                {
                    h.LightUp();
                }
            }
        }

        if (below && left)
        {
           
            foreach (HexController h in HexGrid.hexGrid.lowerLeft)
            {
                float dis = Vector3.SqrMagnitude(snake.transform.position
                                                - h.transform.position);
                if (dis <= snakeHexRadiusSquared)
                {
                    h.LightUp();
                }
            }
        }


        if (below && right)
        {
        
            foreach (HexController h in HexGrid.hexGrid.lowerRight)
            {
                float dis = Vector3.SqrMagnitude(snake.transform.position
                                                - h.transform.position);
                if (dis <= snakeHexRadiusSquared)
                {
                    h.LightUp();
                }
            }
        }
    }

   /* void SnakeSnakeCollision(){
        float snakeSnakeSquared = (snakes [0].radius * 2) * (snakes [0].radius * 2);
        //goes from first snake to 2nd to last, i.e if 4 snakes, 1,2,3
        for (int i = 0; i < snakes.Length; i++)
        {
            if(snakes[i].isAlive){
            //goes to the next snake til the end, i.e. 2,3,4 3,4,4
                for(int j = 0; j < snakes.Length; j++)
                {
                    if(i != j && snakes[j].isAlive){
                        //snake head position
                        Vector3 headPos = snakes[i].transform.position;
                        //compare snake heads
                        float dis = Vector3.SqrMagnitude(headPos 
                                                         - snakes[j].transform.position);
                        if(dis <= snakeSnakeSquared)
                            snakes[i].hitSnakePiece();
                        

                        //compare the rest of the snake against the first head
                        SnakePartController piece = snakes[j].nextPiece;
                        while(piece != null)
                        {
                            float distance = Vector3.SqrMagnitude(headPos 
                                                             - piece.transform.position);
                            if(distance <= snakeSnakeSquared)
                                snakes[i].hitSnakePiece();
                            //next piece in the snake chain
                            piece = piece.pieceBehind;
                        }
                    }
                }
            }
        }
    }*/


}
