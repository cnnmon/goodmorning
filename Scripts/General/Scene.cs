using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    private void Awake()
    //disables all scenes so they don't interfere with each other
    {
        enabled = false;
    }

    public virtual void StartScene()
    {
        transform.GetChild(0).gameObject.SetActive(true); //sets canvas visible when scene starts
        enabled = true;
    }

    public virtual void EndScene()
    {
        transform.GetChild(0).gameObject.SetActive(false); //sets canvas invisible when scene ends
        enabled = false;
    }
}
