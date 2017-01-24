using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeColor : MonoBehaviour {

    // Use this for initialization
    public float speed = 1;
    public float minValue = 0;
    public float maxValue = 1;
    public bool up = false;
    public bool down = false;
    public bool deactivate = true;

    Graphic[] gs;
    Color c;


	
    void Update()
    {
        if (up)
            OnFadeUp();
        if (down)
            OnFadeDown();
    }
    void OnFadeUp()
    {
        if (c.a < maxValue)
        {
            c.a += Time.deltaTime * speed;
            foreach(Graphic a in gs)
                a.color = c;
            if (c.a > maxValue)
            {
                c.a = maxValue;
                foreach (Graphic a in gs)
                    a.color = c;
                up = false;
                this.deactivate = true;
            }
        }
    }

    void OnFadeDown()
    {
        if (c.a > minValue)
        {
            c.a -= Time.deltaTime * speed;
            foreach (Graphic a in gs)
                a.color = c;
            if (c.a < minValue)
            {
                c.a = minValue;
                foreach (Graphic a in gs)
                    a.color = c;
                down = false;
                if(deactivate)
                    gameObject.SetActive(false);
            }
        }
    }

   public void onStartFadeUp()
    {
        gs = gameObject.GetComponentsInChildren<Graphic>();
        c = gs[0].color;
        c.a = minValue;
        foreach (Graphic a in gs)
            a.color = c;
    }

   public void onStartFadeDown()
    {
        gs = gameObject.GetComponentsInChildren<Graphic>();
        c = gs[0].color;
        c.a = maxValue;
        foreach (Graphic a in gs)
            a.color = c;
    }

}
