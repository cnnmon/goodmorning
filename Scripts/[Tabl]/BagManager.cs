using UnityEngine;
using TMPro;

public class BagManager : MonoBehaviour {

    public int objCount = 0;
    public LevelChanger levelChanger;
    public TextMeshProUGUI objCountText;

    private void Start()
    {
        objCountText.text = objCount.ToString() + "/8";
    }

    public void UpdateCount()
    {
        objCount++;
        objCountText.text = objCount.ToString() + "/8";

        if (objCount == 8)
        {
            levelChanger.FadeToNext();
        }
    }

}
