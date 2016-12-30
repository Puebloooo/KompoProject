using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string sceneToLoad;

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
