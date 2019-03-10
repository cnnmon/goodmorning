using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    int levelToLoad;
    
    public void FadeToLevel(int levelNum)
    {
        levelToLoad = levelNum;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNext()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
