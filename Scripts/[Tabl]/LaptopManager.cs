using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopManager : Scene
{
    public LaptopTrigger[] LTs;
    public Manager manager;
    public int columnsDone = 0;
    bool done = false;
    public GameObject hintButton;

    public override void StartScene()
    {
        StartCoroutine(Timer());
        transform.GetChild(0).gameObject.SetActive(true);
        enabled = true;
    }

    public void CheckPuzzle()
    {
        if (columnsDone == 3 && IfRight() && !done)
        //if all columns filled and answer is right and transition has not been called already
        {
            manager.Transition();
            done = true; //to prevent a looping transition
        }
    }

    private bool IfRight()
    //laptoptrigger only stores block names if they match the needed tag name. if that's fulfilled, all that needs to be checked now is if they've been stored in the right order.
    {
        List<string> correctList = new List<string>() { "If", "End" };

        foreach (LaptopTrigger LT in LTs)
        {
            if (LT.blockList[0] != "If" || LT.blockList[1] != "End")
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator Timer()
    //makes hintButton visible after 5 seconds
    {
        yield return new WaitForSeconds(5);
        hintButton.SetActive(true);
    }

}
