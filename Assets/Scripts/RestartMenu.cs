using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

    public string mainMenuScene;
	// Use this for initialization
	public void RestartGame () {
        FindObjectOfType<GameManager>().Reset();
	}
	
	// Update is called once per frame
	public void QuitToMainMenu () {
        SceneManager.LoadScene(mainMenuScene);
	}
}
