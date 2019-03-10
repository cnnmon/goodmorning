using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private void Start()
    {
        if (!GameManager.GM.IsAudioOn())
        {
            GetComponent<Toggle>().isOn = false;
            GameManager.GM.ToggleSound();
        }
    }

    public void OnToggle()
    {
        GameManager.GM.ToggleSound();
    }

}
