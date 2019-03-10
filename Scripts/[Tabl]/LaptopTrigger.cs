using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopTrigger : MonoBehaviour
{
    public string columnTag;
    private int inTrigger = 0;

    public LaptopManager LM;

    //list of gameobjects with matching tag to make sure order is correct
    public List<string> blockList = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger++;

        if (inTrigger <= 2) //only do anything if trigger isnt full
        {
            Puzzle coll = collision.GetComponent<Puzzle>();
            coll.newPos = new Vector2(transform.position.x, (-1.5f * inTrigger) + 3.5f);

            if (coll.tag == columnTag)
            {
                blockList.Add(collision.name);
            }
        }

        if(inTrigger == 2) LM.columnsDone++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(inTrigger == 2) LM.columnsDone--;
        inTrigger--;

        Puzzle coll = collision.GetComponent<Puzzle>();
        coll.newPos = coll.initPos;
        if (coll.tag == columnTag) blockList.Remove(collision.name);
    }
}
