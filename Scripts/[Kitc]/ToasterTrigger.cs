using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterTrigger : MonoBehaviour {

    public GameObject waffleGroup;
    public GameObject wafflePrefab;
    private int numWaffle = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numWaffle++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        numWaffle--;

        if(numWaffle == 0)
        {
            GameObject newWaffle = Instantiate(wafflePrefab, waffleGroup.transform);
            LeanTween.scale(newWaffle, new Vector2(14, 14), 1f).setEase(LeanTweenType.easeOutBack);
        }
    }

}
