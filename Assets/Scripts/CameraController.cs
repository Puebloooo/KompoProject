using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    public PlayerController Player;

	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = Player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distanceToMove = Player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = Player.transform.position;
	}
}
