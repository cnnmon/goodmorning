using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardTrigger : MonoBehaviour {

    public TextMeshProUGUI numWaffleText;
    public GameObject nextButton;
    private int numWaffle = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SpriteRenderer>().sprite.name != "waffle2")
        {
            collision.GetComponent<DADWaffle>().FlipWaffle();
            numWaffle++;
            nextButton.SetActive(true);
            CheckNum(numWaffle);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<SpriteRenderer>().sprite.name != "waffle1")
        {
            collision.GetComponent<DADWaffle>().UnflipWaffle();
            numWaffle--;
            CheckNum(numWaffle);
        }
    }

    void CheckNum(int num) //checks number of waffles in trigger
    {
        if(num > 14)
        {
            numWaffleText.text = "STOP";
        }
        else if(num > 9)
        {
            numWaffleText.text = "too many";
        }
        else
        {
            numWaffleText.text = numWaffle.ToString();
        }
    }

}
