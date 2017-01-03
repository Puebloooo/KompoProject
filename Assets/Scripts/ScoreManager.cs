using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public bool scoreIncreasing;
    public float highScoreCount;
    public float pointsPerSecond;
    public float scoreCount;
    public Text scoreText;
    public Text highScoreText;

	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
	}
	
	void Update () {
        if(scoreIncreasing)
            scoreCount += pointsPerSecond * Time.deltaTime;

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

    }

    public void AddScore(float pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
