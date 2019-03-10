using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrushManager : Scene {

    private Vector3 mousePosition;
    public GameObject arm;
    readonly float moveSpeed = 0.03f;
    float offset = 0;

    public GameObject fire;
    public GameObject fireOverlay;
    public Slider slider;

    public Camera cam;
    public Manager manager;

    private void Start()
    {
        StartCoroutine(CheckSpeed());
    }

    void Update()
    {
        //moves arm slightly according to mouse pos
        mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 50f);
        Vector3 view = cam.ScreenToViewportPoint(Input.mousePosition);

        if (!(view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1))
        {
            arm.transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
            arm.transform.position = new Vector3(arm.transform.position.x, arm.transform.position.y, -8f);
            UpdateSlider();
        }
    }

    void UpdateSlider()
    {
        offset += Mathf.Abs(Input.GetAxis("Mouse X")); //adds delta x to offset
        offset += Mathf.Abs(Input.GetAxis("Mouse Y")); //adds delta y to offset

        slider.value = offset;

        if (slider.value == slider.maxValue) manager.Transition();
    }

    IEnumerator CheckSpeed()
    {
        while (true)
        {
            float lastOffset = offset;
            yield return new WaitForSeconds(1f);

            if ((offset - lastOffset) > 200) //checks mouse speed and sets or puts out the toothbrush fire :)
            {
                fire.SetActive(true);
                fireOverlay.SetActive(true);
            }
            else
            {
                fire.SetActive(false);
                fireOverlay.SetActive(false);
            }
        }
    }

}
