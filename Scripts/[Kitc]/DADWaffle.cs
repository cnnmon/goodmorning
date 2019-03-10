using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DADWaffle : MonoBehaviour {

    public Sprite[] waffles;
    bool selected = false;
    float initZ;

    private void Start()
    {
        initZ = transform.localPosition.z;
    }

    private void Update()
    {
        if (selected == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initZ);
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }


    public void FlipWaffle() //flips waffle - triggered by BoardTrigger
    {
        LeanTween.rotateX(gameObject, 90, 0.3f).setOnComplete(
                    () => {
                        GetComponent<SpriteRenderer>().sprite = waffles[1];
                    }
                );
        LeanTween.rotateX(gameObject, 0, 0.3f).setDelay(0.3f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0.06f, 0.03f);
        GetComponent<BoxCollider2D>().size = new Vector2(3f, 0.8f);
    }

    public void UnflipWaffle() //unflips waffle - triggered by BoardTrigger
    {
        LeanTween.rotateX(gameObject, 90, 0.3f).setOnComplete(
            () => {
                GetComponent<SpriteRenderer>().sprite = waffles[0];
            }
        );
        LeanTween.rotateX(gameObject, 0, 0.3f).setDelay(0.3f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0.01f, 0.02f);
        GetComponent<BoxCollider2D>().size = new Vector2(2.4f, 2.4f);
    }

}
