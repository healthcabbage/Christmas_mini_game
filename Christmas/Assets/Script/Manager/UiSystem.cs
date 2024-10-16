using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSystem : MonoBehaviour
{
    public GameObject soundsettingui;

    public void soundui()
    {
        if (soundsettingui.activeSelf == true)
        {
            soundsettingui.SetActive(false);
        }
        else
        {
            soundsettingui.SetActive(true);
        }

    }
}
