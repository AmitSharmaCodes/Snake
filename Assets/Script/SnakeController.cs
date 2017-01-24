using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {
    static float TWO_PI = Mathf.PI * 2.0f;
    static int MAX_LINKS = 250;
    static int ASSUMED_FRAME_RATE = 60;

    public float turningRate = 1.0f;
    public float currentHeading = 0.0f;
    public float speed = 2.0f;
    public float radius = 0.75f;

    Vector2 currentVelocity;

    Vector3[] positionHistory;
    public GameObject link;

    public GameObject[] links;
    public GameObject[] overlapLinks;
    public Text[] textScore;
    int score;
    int numberOfLinks = 0;
    int positionMarker;
    int betweenMarkers;

    int linksToAdd;
    int newLinkOffset;

    //variables for looping
    float worldWidth;
    float worldHeight;
    float leftWall, rightWall, upWall, downWall;
    float leftBorder, rightBorder, upBorder, downBorder;
    bool crossedWidth, crossedHeight;

    Vector3 heightTemp, widthTemp;

    float radiusSquared;

    public bool wasHit = false;

    void Start () {

        //set proper speed and turnign rate
        switch (MainMenuController.Instance.getSpeedNum())
        {
            case 1:
                speed = 5.0f;
                break;
            case 2:
                speed = 7.5f;
                break;
            case 3:
                speed = 10.0f;
                break;
        }
        turningRate = speed * .5f;

        //assuming 60 frames per second
        betweenMarkers = (int)((radius*2) / speed * ASSUMED_FRAME_RATE) - 1;

        Debug.Log(betweenMarkers);
        //200 max length of snake
        positionHistory = new Vector3[MAX_LINKS * betweenMarkers];
        positionMarker = 0;
        currentVelocity = new Vector2(1.0f * speed, 0.0f);

        //precreate all the links at start
        links = new GameObject[MAX_LINKS];
        for(int i = 0; i < MAX_LINKS; i++)
        {
            GameObject temp = (GameObject)Instantiate(link);
            temp.SetActive(false);
            links[i] = temp;
        }

        //precreate all the overlap links
        int overlapMax = MAX_LINKS * 3;
        overlapLinks = new GameObject[overlapMax];
        for (int i = 0; i < overlapMax; i++)
        {
            GameObject temp = (GameObject)Instantiate(link);
            temp.SetActive(false);
            overlapLinks[i] = temp;
        }

        linksToAdd = 2;
        newLinkOffset = 0;

        //world length and height for the partial overlapping
        worldHeight = 10;
        worldWidth = ((float)Screen.width) / Screen.height * worldHeight;
        leftWall = -worldWidth + radius;
        rightWall = worldWidth - radius;
        upWall = worldHeight - radius;
        downWall = -worldHeight + radius;

        //borders are for the actual wrapping, moving the snake, not making duplicates 
        leftBorder = -worldWidth - radius;
        rightBorder = worldWidth + radius;
        upBorder = worldHeight + radius;
        downBorder = -worldHeight - radius;

        worldHeight *= 2;
        worldWidth *= 2;
        crossedWidth = false;
        crossedHeight = false; 



        Debug.Log("worldHeight:WorldWidth = " + worldHeight + ":" + worldWidth);

        radiusSquared = (2 * radius) * (2 * radius);
        for(int i = 0; i < 4; i++)
            textScore[i].text = "3";
        score = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameState.gameState.paused)
        {
            //heading
            currentHeading += turningRate * Time.deltaTime;
            if (currentHeading > TWO_PI)
                currentHeading -= TWO_PI;
            else if (currentHeading < 0)
                currentHeading += TWO_PI;

            //velocity
            currentVelocity.x = Mathf.Cos(currentHeading) * speed;
            currentVelocity.y = Mathf.Sin(currentHeading) * speed;

            //position
            Vector3 pos = transform.position;
            pos.x += currentVelocity.x * Time.deltaTime;
            pos.y += currentVelocity.y * Time.deltaTime;

            //see if new position is breaking one of the borders, if so, wrap it around
            if (pos.x < leftBorder)
            {
                pos.x += worldWidth;
            }
            else if (pos.x > rightBorder)
            {
                pos.x -= worldWidth;
            }

            if (pos.y < downBorder)
            {
                pos.y += worldHeight;
            }
            else if (pos.y > upBorder)
            {
                pos.y -= worldHeight;
            }

            transform.position = pos;

            //update position history array
            positionHistory[positionMarker] = pos;
            ++positionMarker;

            //update crossover for front
            if (pos.x < leftWall)
            {
                crossedWidth = true;
                widthTemp = pos;
                widthTemp.x += worldWidth;
               
            }
            else if (pos.x > rightWall)
            {
                crossedWidth = true;
                widthTemp = pos;
                widthTemp.x -= worldWidth;
               
            }

            if (pos.y < downWall)
            {
                crossedHeight = true;
                heightTemp = pos;
                heightTemp.y += worldHeight;
            }
            else if (pos.y > upWall)
            {
                crossedHeight = true;
                heightTemp = pos;
                heightTemp.y -= worldHeight;
            }
            
            overlapLinks[0].SetActive(crossedWidth);
            overlapLinks[1].SetActive(crossedHeight);
            overlapLinks[2].SetActive(crossedHeight && crossedWidth);
            if (crossedWidth)
                overlapLinks[0].transform.position = widthTemp;
            if (crossedHeight)
                overlapLinks[1].transform.position = heightTemp;
            if(crossedHeight && crossedWidth)
            {
                //should have the x of the width temp and y of the heightTemp
                widthTemp.y = heightTemp.y;
                overlapLinks[2].transform.position = widthTemp;
            }

            crossedHeight = false;
            crossedWidth = false;

            //if the positionMarker has reached the end of the array loop it around
            if (positionMarker == positionHistory.Length)
            {
                Debug.Log("reset position");
                positionMarker = 0;
            }

            //update all the link positions
            Vector3 temp;
            for (int i = 0; i < numberOfLinks; i++)
            {
                 temp = positionHistory[indexInPositionHistory(i)];
                 links[i].transform.position = temp;
                //crossing over make a duplicate for the other half
                if (temp.x < leftWall)
                {
                    crossedWidth = true;
                    widthTemp = temp;
                    widthTemp.x += worldWidth;

                }
                else if (temp.x > rightWall)
                {
                    crossedWidth = true;
                    widthTemp = temp;
                    widthTemp.x -= worldWidth;

                }

                if (temp.y < downWall)
                {
                    crossedHeight = true;
                    heightTemp = temp;
                    heightTemp.y += worldHeight;
                }
                else if (temp.y > upWall)
                {
                    crossedHeight = true;
                    heightTemp = temp;
                    heightTemp.y -= worldHeight;
                }
                overlapLinks[(i + 1) * 3].SetActive(crossedWidth);
                overlapLinks[(i + 1) * 3 + 1].SetActive(crossedHeight);
                overlapLinks[(i + 1) * 3 + 2].SetActive(crossedHeight && crossedWidth);

                if (crossedWidth)
                    overlapLinks[(i + 1) * 3].transform.position = widthTemp;
                if (crossedHeight)
                    overlapLinks[(i + 1) * 3 + 1].transform.position = heightTemp;
                if (crossedHeight && crossedWidth)
                {
                    widthTemp.y = heightTemp.y;
                    overlapLinks[(i + 1) * 3 + 2].transform.position = widthTemp;
                }
                crossedHeight = false;
                crossedWidth = false;
            }

            //handle links to Add
            handleNewLinks();

            //does all the collision, handles all the cases
            collisionWithSelf();

            //update position of score
            textScore[0].transform.position = transform.position;
            for (int i = 0; i < 3; i++)
            {
                textScore[i + 1].gameObject.SetActive(overlapLinks[i].activeSelf);
                if(overlapLinks[i].activeSelf)
                {
                    textScore[i + 1].gameObject.transform.position = overlapLinks[i].transform.position;
                }
            }
        }
    }

    private void collisionWithSelf()
    {
        if (numberOfLinks < 8)
            return;

        Vector3 headpos = transform.position;
        for(int i = 7; i < numberOfLinks; i++)
        {
            //check links
            //Debug.Log("MORE THAN 8");
            float squaredDis = Vector3.SqrMagnitude(links[i].transform.position - headpos);
            //Debug.Log("Distance: " + squaredDis + " Radius Squared: " + radiusSquared);
            if(squaredDis < radiusSquared)
            {
                //most common hit, with the snake head, and the body parts, no duplicates worried about
              
                wasHit = true;
            }

            //check the overlaps
            for (int j = 1; j <= 3; j++)
            {
                if (overlapLinks[(i + 1) * 3 + j].activeSelf)
                {
                    float squaredOverLapDis = Vector3.SqrMagnitude(overlapLinks[(i + 1) * 3 + j].transform.position - headpos);
                    //Debug.Log("Distance: " + squaredDis + " Radius Squared: " + radiusSquared);
                    if (squaredOverLapDis < radiusSquared)
                    {
                        //this is the snake head, and worrying about the duplicated body parts 
                        
                        wasHit = true;
                    }
                }
            }
        }

        //check the overlaps of the snake head, if there are overlaps with the snake head then you have to check for each snakehead
        for (int k = 0; k < 3; k++)
        {
            if (overlapLinks[k].activeSelf)
            {
                Vector3 headOverLappos = overlapLinks[k].transform.position;
                for (int i = 7; i < numberOfLinks; i++)
                {
                    //check links
                    //Debug.Log("MORE THAN 8");
                    float squaredDis = Vector3.SqrMagnitude(links[i].transform.position - headOverLappos);
                    //Debug.Log("Distance: " + squaredDis + " Radius Squared: " + radiusSquared);
                    if (squaredDis < radiusSquared)
                    {
                        //this is the duplicate snake head and the regular snake parts
                       
                        wasHit = true;

                    }

                    //check the overlaps
                    for (int j = 1; j <= 3; j++)
                    {
                        if (overlapLinks[(i + 1) * 3 + j].activeSelf)
                        {
                            float squaredOverLapDis = Vector3.SqrMagnitude(overlapLinks[(i + 1) * 3 + j].transform.position - headOverLappos);
                            //Debug.Log("Distance: " + squaredDis + " Radius Squared: " + radiusSquared);
                            if (squaredOverLapDis < radiusSquared)
                            {
                                //and finally the duplicate snake head worrying about the duplicate parts
                               
                                wasHit = true;
                            }
                        }
                    }
                }
            }
        }
    }


    public void switchDirection()
    {
        turningRate = -turningRate;
    }

    public void AddLink()
    {
        linksToAdd++;
        score++;
        for(int i = 0; i < 4; i++)
            textScore[i].text = score.ToString();
    }

    /// <summary>
    /// based on the number the link is, get the corresponding position in the position history
    /// </summary>
    /// <param name="indexInPieces"></param>
    /// <returns></returns>
    private int indexInPositionHistory(int indexInPieces)
    {
        int index = positionMarker - (betweenMarkers * (indexInPieces + 1));
        if (index < 0)
            index += positionHistory.Length;
        return index;
    }

    private void handleNewLinks()
    {
        if (linksToAdd > 0)
        {
            //new link to make
            if (newLinkOffset == 0)
                links[numberOfLinks].SetActive(true);

            //put the new link to add at the position of the last link plus an offset
            links[numberOfLinks].transform.position = positionHistory[indexInPositionHistory(numberOfLinks - 1) - newLinkOffset];
            newLinkOffset++;

            //the offset has slid to the final amount
            if (newLinkOffset == betweenMarkers)
            {
                newLinkOffset = 0;
                ++numberOfLinks;
                --linksToAdd;
               // Debug.Log(numberOfLinks);
            }
        }
    }
    public int size()
    {
        return 1 + numberOfLinks;
    }
}
