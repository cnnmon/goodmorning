using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Vector3 initPos;
    bool selected = false;

    //newPos can either be the block's initial position that it resets to, or it'll get edited and replaced by a new value once it hits a section it can stay (through collision). 
    public Vector3 newPos;

    public LaptopManager LM;

    public void Start()
    {
        initPos = transform.position;
        newPos = initPos;
    }

    private void Update()
    {
        if (selected == true)
        //tracks position to mouse
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPos.x, cursorPos.y, -1);
        }

        if (Input.GetMouseButtonUp(0))
        //if mouse up, go to laptopmanager and check if all columns are filled and the solution is correct
        {
            selected = false;
            transform.position = newPos;

            LM.CheckPuzzle();
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
