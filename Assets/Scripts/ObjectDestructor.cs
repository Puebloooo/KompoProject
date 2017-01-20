using UnityEngine;

public class ObjectDestructor : MonoBehaviour {

    public GameObject objectDestructionPoint;

	void Start () {
        objectDestructionPoint = GameObject.Find("ObjectDestructionPoint");
	}
	
	void Update () {
        if (transform.position.x < objectDestructionPoint.transform.position.x)
            gameObject.SetActive(false);
	}
}
