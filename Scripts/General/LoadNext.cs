using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour {

	private void Awake () {
        SceneManager.LoadScene(SceneManager.sceneCount);
	}
	
}
