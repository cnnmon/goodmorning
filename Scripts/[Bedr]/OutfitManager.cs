using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitManager : Scene {

    public GameObject mirror;
    public GameObject nextButton;
    public Sprite[] mirrors;

    public int currentOutfit = 0;
    private int switchNum = 0;

    public void ChangeOutfit(int num)
    //changes sprite whenever outfits are dropped onto the collider (mirror)
    {
        currentOutfit = num;
        CheckSwitch();
        mirror.GetComponent<SpriteRenderer>().sprite = mirrors[num];
    }

    void CheckSwitch()
    //sets nextButton visible after a few selections have been tried
    {
        if (switchNum == 2) nextButton.SetActive(true);
        else switchNum++;
    }

}
