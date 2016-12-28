using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;
    private PlatformDestructor[] platformList;
    private ScoreManager scoreManager;

    public PlayerController player;
    public Transform platformGenerator;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;

        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestructor>();
        for (int i = 0; i < platformList.Length; i++)
            platformList[i].gameObject.SetActive(false);

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
}
