using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DADOutfit : MonoBehaviour
{
    public OutfitManager outfitManager;
    public int outfitInt;
    bool selected = false;
    Vector3 initPos;
    int lastOutfitInt = -1;

    public bool inTrigger = false;

    public void Start()
    {
        initPos = transform.position;
        CheckOutfit();
    }

    private void Update()
    {
        if(outfitManager.enabled)
        {
            if (selected == true)
            {
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(cursorPos.x, cursorPos.y, -1);
            }

            if (Input.GetMouseButtonUp(0))
            {
                selected = false;

                if (inTrigger)
                {
                    outfitManager.ChangeOutfit(outfitInt);
                }
                transform.position = initPos;
            }

            CheckOutfit();
        }
    }

    void CheckOutfit()
    {
        //makes sure outfit has changed before running... otherwise runs in between change
        if (lastOutfitInt != outfitManager.currentOutfit)
        {
            if (outfitManager.currentOutfit == outfitInt) gameObject.GetComponent<SpriteRenderer>().enabled = false;
            else gameObject.GetComponent<SpriteRenderer>().enabled = true;

            lastOutfitInt = outfitManager.currentOutfit;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

}
