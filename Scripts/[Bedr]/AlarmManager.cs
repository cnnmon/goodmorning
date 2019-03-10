using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlarmManager : Scene {

    public GameObject sliderEmote;
    public TextMeshProUGUI reactText;
    public GameObject overlay;

    public Sprite[] overlays;
    public Sprite[] emotes;

    readonly string[] react = new string[] { "ok!", "great!", ":D", "yawwn..", "zzZ"};

    int currentOverlay = 0;
    public bool inTrigger = false;
    public Manager manager;

    public override void StartScene()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        enabled = true;
        LeanTween.moveX(sliderEmote, sliderEmote.transform.position.x + 5.7f, 2f).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong();
        UpdateOverlay();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inTrigger == true)
                //opens eyes more if click was in trigger field
            {
                if(currentOverlay < (overlays.Length-1))
                {
                    currentOverlay++;
                    UpdateOverlay();
                    sliderEmote.GetComponent<SpriteRenderer>().sprite = emotes[Random.Range(0, emotes.Length)];

                    //generates text
                    reactText.text = react[Random.Range(0, react.Length)];
                    LeanTween.scale(reactText.gameObject, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack);
                    LeanTween.scale(reactText.gameObject, new Vector3(0, 0, 1), 0.5f).setEase(LeanTweenType.easeOutBack).setDelay(1f);
                }
                else manager.Transition();
            }
            else if (inTrigger == false && currentOverlay > 0)
                //closes eyes more if click wasn't in trigger field
            {
                currentOverlay--;
                UpdateOverlay();
            }
        }
    }

    void UpdateOverlay()
    {
        overlay.GetComponent<SpriteRenderer>().sprite = overlays[currentOverlay];
    }

    public override void EndScene()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        enabled = false;
        sliderEmote.SetActive(false);
    }

}
