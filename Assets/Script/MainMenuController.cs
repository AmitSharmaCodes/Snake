using UnityEngine;
using System.Collections;

public  class MainMenuController {

    private static MainMenuController _instance = null;
    private  int players = 1;
    private  int speed = 1;
    private  bool vibrate = true;
    private  bool music = true;
    private float brightnessIntensity = 1;
    public static MainMenuController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MainMenuController();
            }
            return _instance;
        }
    }

    public int getPlayerNum()
    {
        return players;
    }
    public void setPlayerNum(int i)
    {
        players = i;
    }

    public int getSpeedNum()
    {
        return speed;
    }
    public void setSpeed(int i)
    {
        speed = i;
    }
    public bool getVibrate()
    {
        return vibrate;
    }
    public void setVibrate(bool b)
    {
        vibrate = b;
    }

    public bool getMusic()
    {
        return music;
    }
    public void setMusic(bool b)
    {
        music = b;
    }
    public void setBrightness(float f)
    {
        brightnessIntensity = f;
    }
    public float getBrightness()
    {
        return brightnessIntensity;
    }
}
