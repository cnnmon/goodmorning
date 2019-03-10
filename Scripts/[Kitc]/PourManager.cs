using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PourManager : MonoBehaviour {

    public GameObject particlePrefab;
    public GameObject particleGroup;
    public GameObject kettle;

    public GameObject plant;
    public GameObject plantDialogue;
    public Slider slider;

    bool dialogueReady = true;
    Vector3 dialoguePos;

    public LevelChanger levelChanger;

    private void Start()
    {
        StartCoroutine(ParticleGenerator());
        dialoguePos = plantDialogue.transform.position;
    }

    private void Update() 
        //tracks kettle to mouse
    {
        Vector3 cursorPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 2f);
        kettle.transform.position = cursorPos;
    }

    public void UpdateSlider(int particleNum) 
        //updates slider to particleNum
    {
        slider.value = particleNum;
        if (slider.value == slider.maxValue) levelChanger.FadeToNext();
    }

    IEnumerator ParticleGenerator()
        //generates particles at adjusted position on kettle
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 kettlePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 1.6f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.2f, -1.1f);
            var particles = Instantiate(particlePrefab, kettlePos, Quaternion.identity);
            particles.transform.parent = particleGroup.transform;
        }
    }

    public void DialogueTrigger()
        //if not already animating, animate the dialogue pop-up
    {
        if (dialogueReady)
        {
            dialogueReady = false;
            LeanTween.scale(plantDialogue, new Vector3(0.65f, 0.65f, 0.65f), 0.5f).setEase(LeanTweenType.easeOutBack);
            LeanTween.moveX(plantDialogue, dialoguePos.x + 1f, 0.7f).setEase(LeanTweenType.easeInOutQuad);
            LeanTween.alpha(plantDialogue, 0f, 0.2f).setDelay(1.5f).setOnComplete(
                () => {
                    dialogueReady = true;
                });     

            plantDialogue.transform.position = dialoguePos;
            plantDialogue.transform.localScale = new Vector3(0f, 0f, 0f);

            Color tmp = plantDialogue.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            plantDialogue.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

}
 