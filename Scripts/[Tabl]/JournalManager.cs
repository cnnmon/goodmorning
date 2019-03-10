using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : Scene
{
    public Transform bg;
    public Transform input;
    readonly float moveSpeed = 0.05f;

    public InputField inputField;
    public GameObject nextButton;

    public Camera cam;

    private void Update()
    { //follow mouse

        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 50f);
        Vector3 view = cam.ScreenToViewportPoint(Input.mousePosition);

        if (!(view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1))
        {
            input.transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
            input.transform.position = new Vector2(input.transform.position.x-1, input.transform.position.y-2.5f);

            bg.transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }

        if(inputField.text.Length >= 50)
        {
            nextButton.SetActive(true);
        }
    }
}
