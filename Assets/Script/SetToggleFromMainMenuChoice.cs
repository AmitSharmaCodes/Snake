using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SetToggleFromMainMenuChoice : MonoBehaviour {

    public Toggle[] toggles;
    public void onClickPlayer()
    {
        toggles[MainMenuController.Instance.getPlayerNum() - 1].isOn = true;
    }

    public void onClickSpeed()
    {
        toggles[MainMenuController.Instance.getSpeedNum() - 1].isOn = true;
    }
}
