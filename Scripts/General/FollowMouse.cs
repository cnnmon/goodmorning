using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject gameObj;
    readonly float moveSpeed = 0.05f;

    void Update()
        //mouse is tracked by gameObj to create a "looking around" effect
    {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 50f);

        if (mousePosition.x > -12f && mousePosition.x < 9.7f && mousePosition.y > -5f && mousePosition.y < 7f)
        {
            gameObj.transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

}
