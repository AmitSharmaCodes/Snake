using UnityEngine;
using System.Collections;

public class TargetBubbleController : MonoBehaviour {

	// Use this for initialization
    public float radius;
    public float speed = 15;
    public float maxSize = 35;

    float radiusSqr;

    GlowBoxController[] boxes;
    bool[] hasHit;
	void Start () {
    }   

    void OnEnable()
    {
        if (boxes == null)
            boxes = SquareGrid.box.boxes;

        if(hasHit == null)
            hasHit = new bool[boxes.Length];

        for (int i = 0; i < boxes.Length; i++)
            hasHit[i] = false;
        radius = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        radius += Time.deltaTime * speed;
        if (radius > maxSize)
            gameObject.SetActive(false);
        CollisionWithBoxes();
	    
	}

    void CollisionWithBoxes(){
        radiusSqr = radius * radius;
        for(int i = 0; i < boxes.Length; i++)
        {
            if(!hasHit[i]){
                Vector3 point = transform.position;
            
                if (point.x > boxes[i].right)
                    point.x = boxes[i].right;
                else if (point.x < boxes[i].left)
                    point.x = boxes[i].left;
            
                if (point.y > boxes[i].top)
                    point.y = boxes[i].top;
                else if (point.y < boxes[i].bottom)
                    point.y = boxes[i].bottom;
            
                float squaredDistance = Vector3.SqrMagnitude(point - transform.position);
                if (squaredDistance < radiusSqr){
                    boxes[i].hitBubble();
                    hasHit[i] = true;
                }
            }
        }
    }
}
