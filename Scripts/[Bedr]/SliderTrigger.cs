using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTrigger : MonoBehaviour {

    public AlarmManager alarmManager;
    public GameObject lines;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alarmManager.inTrigger = true;
        lines.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alarmManager.inTrigger = false;
        lines.SetActive(false);
    }

}
