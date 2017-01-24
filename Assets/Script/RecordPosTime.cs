using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct TimePos{
    public Vector3 pos;
    public float time;
}

public class RecordPosTime : MonoBehaviour {

	// Use this for initialization
    public Queue<TimePos> timePos;
    public bool asleep = true;
    public int queueLength = 0;
	void Start () {
        timePos = new Queue<TimePos>();
      
	}
    void OnDisable()
    {
        if(timePos != null)
            timePos.Clear();
        asleep = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!asleep && !GameState.gameState.paused)
            updatePositionQueue();

        queueLength = timePos.Count;
	}

    public void updatePositionQueue()
    {
            TimePos obj;
            obj.pos = transform.position;
            obj.time = Time.time;
            timePos.Enqueue(obj);
    }

}
