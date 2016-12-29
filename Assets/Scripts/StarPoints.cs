using UnityEngine;
using System.Collections;

public class StarPoints : MonoBehaviour {

    private ScoreManager scoreManager;

    public float score;
	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
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
