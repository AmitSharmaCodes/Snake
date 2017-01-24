using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BrightnessSlider : MonoBehaviour {
    public Slider s;
    void OnEnable()
    {
        s.value = MainMenuController.Instance.getBrightness();
    }
}
