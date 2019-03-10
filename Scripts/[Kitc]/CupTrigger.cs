using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrigger : MonoBehaviour {

    public PourManager pourManager;
    int particleNum = 0;

    void OnTriggerEnter2D(Collider2D collider) //asks pourmanager to update slider
    {
        if(collider.tag == "Particle")
        {
            particleNum++;
            pourManager.UpdateSlider(particleNum);
        }
    }

}
