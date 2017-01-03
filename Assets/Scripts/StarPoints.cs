using UnityEngine;
using System.Collections;

public class StarPoints : MonoBehaviour {

    private ScoreManager scoreManager;

    public float score;
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Player")
        {
            scoreManager.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}
