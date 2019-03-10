using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;
    AudioSource audioSource;

    public void Awake()
    {
        JustMonika();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void JustMonika()
    {
        if (GM == null) GM = this;
        else if (GM != this) Destroy(gameObject);
    }

    public void ToggleSound()
    {
        if (IsAudioOn() == true) audioSource.volume = 0f;
        else audioSource.volume = 0.5f;
    }

    public bool IsAudioOn()
    {
        if (audioSource.volume == 0.5) return true;
        else return false;
    }
}
