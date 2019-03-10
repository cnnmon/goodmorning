using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<DADOutfit>().inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<DADOutfit>().inTrigger = false;
    }
}
