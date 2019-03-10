using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Scene[] scenes;
    public int sceneInt;

    public GameObject sceneObj;
    public LevelChanger levelChanger;

    void Start()
    {
        sceneObj.transform.position = new Vector3(2.2f + (sceneInt * 13), 1, -25);
        scenes[sceneInt].StartScene();
    }

    public void Transition()
    //Changes scene and enables next script
    {
        if(sceneInt+1 != scenes.Length)
        {
            Vector2 sceneObjPos = sceneObj.transform.position;
            scenes[sceneInt].EndScene();

            LeanTween.moveX(sceneObj, sceneObjPos.x + 13, 1f).setOnComplete(
                        () => {
                            sceneInt++;
                            scenes[sceneInt].StartScene();
                            
                        }
                    );
        } else
        {
            levelChanger.FadeToNext();
        }
    }
}
