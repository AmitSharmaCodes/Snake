using UnityEngine;
using System.Collections;

public class HexController : MonoBehaviour {

	// Use this for initialization
    public float radius = 1.26f;
    public float turnSpeed = 100;
    public float lightUpSpeed = 1;

    bool turn;
    float turnAccu; //the amount the hex has turn't, if it turned 30 degrees, it is done
    Vector3 deltaTurn;

    bool lightUp, lightDown;
    SpriteRenderer rend;
    float baseAlpha;

    void Start () {
        turn = false;
        lightUp = false;
        lightDown = false;

        turnAccu = 0;
        deltaTurn = new Vector3();
        rend = GetComponent<SpriteRenderer>();
        baseAlpha = rend.color.a;
	
	}
	
	// Update is called once per frame
	void Update () {
        TurnUpdate();
        LightUpdate();
	
	}
    void LightUpdate(){
        if (lightDown)
        {
            Color c = rend.color; 
            c.a -= Time.deltaTime * lightUpSpeed;
            if(c.a < baseAlpha)
            {
                c.a = baseAlpha;
                lightDown = false;
            }

            rend.color = c;
        }
        else if (lightUp)
        {
            Color c = rend.color; 
            c.a += Time.deltaTime * lightUpSpeed;
            if(c.a > .6f) //max color
            {
                c.a = .6f;
                lightUp = false;
                lightDown = true;
            }
            rend.color = c;
        }
    }

    void TurnUpdate(){
        if (turn){
            deltaTurn.z = Time.deltaTime * turnSpeed * 2;
            turnAccu += deltaTurn.z;
            if(turnAccu > 60)
            {
                turnAccu -= 60;
                deltaTurn.z -= turnAccu;
                turnAccu = 0;
                turn = false;
            }
            transform.Rotate(deltaTurn);
        }
    }

    public void Turn(){
        if(!turn)
            turn = true;
    }

    public void LightUp(){
         if(!lightUp)
            lightUp = true;
      
    }
}
