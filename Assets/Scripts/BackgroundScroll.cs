using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    private Vector3 previousCameraPosition;
    
    public float smoothing;
    public Transform background;
    

    void Start () {
        previousCameraPosition = transform.position;
	}
	
	void LateUpdate () {
        Vector3 parallax = (previousCameraPosition - transform.position) * ((-10)/smoothing);
        background.position = new Vector3(background.position.x + parallax.x, background.position.y, background.position.z);
        previousCameraPosition = transform.position;
        
    }
 
}
