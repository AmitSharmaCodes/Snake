using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIClickEvents : MonoBehaviour {

    public Slider s;

    public void onOneClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setPlayerNum(1);
    }

    public void onTwoClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setPlayerNum(2);

    }

    public void onThreeClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setPlayerNum(3);
    }

    public void onFourClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setPlayerNum(4);
    }

    public void onSlowClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setSpeed(1);
    }
    public void onMediumClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setSpeed(2);
    }
    public void onFastClick(bool b)
    {
        if (b == true)
            MainMenuController.Instance.setSpeed(3);
    }
    public void onMusicClick(bool b)
    {
        MainMenuController.Instance.setMusic(b);
    }

    public void onVibrateClick(bool b)
    {
        MainMenuController.Instance.setVibrate(b);
    }
    public void onSliderClick()
    {
        MainMenuController.Instance.setBrightness(s.value);
    }
}
