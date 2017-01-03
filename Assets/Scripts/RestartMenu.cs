using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

    public string mainMenuScene;

	public void RestartGame () {
        FindObjectOfType<GameManager>().Reset();
	}
	
	public void QuitToMainMenu () {
        SceneManager.LoadScene(mainMenuScene);
	}
}
