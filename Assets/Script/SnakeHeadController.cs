using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SnakeHeadController : MonoBehaviour {

	// Use this for initialization
	static float TWO_PI = Mathf.PI * 2.0f;

	public float turningRate = 1.0f;
	public float currentHeading = 0.0f;
	public float speed = 2.0f;
    public float radius = 0.75f;
	Vector2 currentVelocity;

    public ObjectPooler snakePiece;
    public GameObject snakePiecePre;
    public GameObject lastSnakePiece;
    public SnakePartController nextPiece;
   //previous Positions

    float left, right, top, bottom;

    Vector2 velo;

   public int numberOfPieces;
    Color currentColor;

   public Text text;

   public GlowTrailController trail;
    public ObjectPooler HitEffect;

   bool isInvincible;
   float invincibleTime;
   public float timeForInvincible = 1.0f;
   public bool wasHit;
   public bool isAlive;


	void Start () {
        Debug.Log(MainMenuController.Instance.getSpeedNum());
        switch(MainMenuController.Instance.getSpeedNum())
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


        isInvincible = false;
        isAlive = true;
        invincibleTime = 0.0f;

		currentVelocity = new Vector2(1.0f * speed, 0.0f);
		velo = currentVelocity;
		currentHeading = 0.0f;

        numberOfPieces = 0;
        Camera cam = FindObjectOfType<Camera>();
        float height = cam.orthographicSize;
        float width = height * Screen.width / ((float)Screen.height);
        top = height + radius;
        bottom = -height - radius;
        right = width + radius;
        left = -width - radius;

        currentColor = GetComponent<SpriteRenderer>().color;
        currentColor.a = 0.8f;
       
    }
	// Update is called once per frame
	void Update () {    
        //computer
 //           if(Input.GetMouseButtonDown(0))
 //           switchDirection();
        //android
//		if(Input.touchCount > 0)
//            if(Input.GetTouch(0).phase == TouchPhase.Began)
//			    switchDirection();
        if (!GameState.gameState.paused)
        {
            currentHeading += turningRate * Time.deltaTime;
            capCurrentHeading();
            updateVelocity();
            updateInvincible();
        }
	}

    void OnBecameInvisible() {
        Vector3 pos = transform.position;
        if (pos.x >= right) 
            pos.x = left;
        else if (pos.x <= left)
            pos.x = right;

        if (pos.y >= top)
            pos.y = bottom;
        else if(pos.y <= bottom)
            pos.y = top;
        transform.position = pos;
    }

    public void hitTarget(){
        addSnakePart();
        UpdateScore();
    }

    private void UpdateScore(){
        text.text = (numberOfPieces + 1).ToString();
    }
    public void hitSnakePiece(){
        wasHit = true;
        //SpawnHitEffect();
        //removeSnakePart();
    }
    public void killSnake(){
        isAlive = false;
        SnakePartController np = nextPiece;
        while (np != null)
        {
            SnakePartController current = np;
            np = np.pieceBehind;
            current.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    private void SpawnHitEffect()
    {
        if (numberOfPieces != 0 && !isInvincible)
        {
            GameObject effect = HitEffect.GetPooledObject();
            HitEffectController hit = effect.GetComponent<HitEffectController>();
            Color temp = currentColor;
            temp.a = 1.0f;
            hit.sprite.color = temp;
            hit.hitTime = timeForInvincible;
            hit.snake = gameObject;
            effect.transform.position = transform.position;
            effect.SetActive(true);
        }
    }
	
    public void removeSnakePart(){
        SpawnHitEffect();
        if (numberOfPieces != 0 && !isInvincible)
        {
            isInvincible = true;    
            if(numberOfPieces != 1)
            {
                //the last piece is chopped off, and the piece in front of last is now last
                GameObject temp  = lastSnakePiece;
                lastSnakePiece = lastSnakePiece.GetComponent<SnakePartController>().pieceInFront.gameObject;
                temp.SetActive(false);
            }
            else
            {
                lastSnakePiece.SetActive(false);
                nextPiece = null;
                lastSnakePiece = null;

            }
            numberOfPieces--;
            text.text = (numberOfPieces + 1).ToString();
        }
    }
    private void addSnakePart(){
        numberOfPieces++;
        //GameObject obj = snakePiece.GetPooledObject(); // make the newest piece

        GameObject obj = (GameObject)Instantiate(snakePiecePre);

        //point it to the piece in front of it, and position it
        SnakePartController snakePartControl =  obj.GetComponent<SnakePartController>();
        //there is no second piece
        if (lastSnakePiece == null)
        {
            RecordPosTime headRecordTime = gameObject.GetComponent<RecordPosTime>();
            headRecordTime.asleep = false;
            snakePartControl.pieceInFront = headRecordTime; 
            obj.transform.position = transform.position;
            snakePartControl.isSafe = true;
            snakePartControl.pieceBehind = null;
            nextPiece = snakePartControl;
        } 
        else {
            snakePartControl.pieceInFront = lastSnakePiece.GetComponent<RecordPosTime>();
            snakePartControl.pieceBehind = null;
            lastSnakePiece.GetComponent<SnakePartController>().pieceBehind = snakePartControl;
            obj.transform.position = lastSnakePiece.transform.position;

            if(numberOfPieces <= 6)
                snakePartControl.isSafe = true;
        }
        snakePartControl.head = this;
        obj.GetComponent<SpriteRenderer>().color = currentColor;
        obj.SetActive(true);
       
        lastSnakePiece = obj;

        trail.addGlowPiece();
    }
    //keeps currentheading between 0 - 2pi to prevent degredation of maths
    private void capCurrentHeading(){
		if (currentHeading > TWO_PI)
			currentHeading -= TWO_PI;
		else if (currentHeading < 0)
			currentHeading += TWO_PI;
	}

	//updates velocity of rigidbody based on heading and speed
	private void updateVelocity()
	{
		currentVelocity.x = Mathf.Cos (currentHeading) * speed;
		currentVelocity.y = Mathf.Sin (currentHeading) * speed;
		velo = currentVelocity;

        Vector3 pos = transform.position;
        pos.x += velo.x * Time.deltaTime;
        pos.y += velo.y  * Time.deltaTime;
        transform.position = pos;

	}

    private void updateInvincible()
    {
        if(isInvincible)
        {
            invincibleTime += Time.deltaTime;
            if(invincibleTime > timeForInvincible)
            {
                isInvincible = false;
                invincibleTime = 0.0f;
            }
        }
    }


	public void switchDirection(){
		turningRate = -turningRate;
	}
}
