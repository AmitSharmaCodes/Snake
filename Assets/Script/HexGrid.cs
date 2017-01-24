using UnityEngine;
using System.Collections;

 public class HexGrid : MonoBehaviour {

	// Use this for initialization
    static public HexGrid hexGrid;
     public HexController[] hexes;
     public HexController[] upperLeft;
     public HexController[] upperRight;
     public HexController[] lowerLeft;
     public HexController[] lowerRight;

    void Awake()
    {

        if (hexGrid == null)
            hexGrid = this;
        else if (hexGrid != this)
            Destroy(gameObject);
    }

    public void Turn()
    {
        foreach (HexController h in hexes)
            h.Turn();
    }

}
