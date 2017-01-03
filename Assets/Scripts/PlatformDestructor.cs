using UnityEngine;

public class PlatformDestructor : MonoBehaviour {

    public GameObject platformDestructionPoint;

	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	void Update () {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
            gameObject.SetActive(false);
	}
}
