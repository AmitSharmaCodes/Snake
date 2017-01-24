using UnityEngine;
using System.Collections;

public class ToggleGameObjects : MonoBehaviour {

    public GameObject[] obj;
    public void onClick()
    {
        foreach (GameObject g in obj)
            g.SetActive(!g.activeSelf);
    }
}
