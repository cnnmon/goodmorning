using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject box;
    public LevelChanger levelChanger;

    void Start()
    //sets animation for box on last scene
    {
        LeanTween.moveX(box, box.transform.position.x + 7, 2.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(
                () => {
                    LeanTween.moveX(box, box.transform.position.x - 0.5f, 3.5f).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong();
                });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            levelChanger.FadeToNext();
        }
    }

}
