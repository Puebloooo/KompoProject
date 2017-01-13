using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {

    private float backgroundTileWidth;
    public GameObject newBackgroundTile;
    public ObjectPooler backgroundTilesPool;
    public Transform generationPoint;
    // Use this for initialization
    void Start () {
	    backgroundTileWidth = 53.21f;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + backgroundTileWidth, transform.position.y, transform.position.z);
            newBackgroundTile = backgroundTilesPool.GetPooledObject();
            newBackgroundTile.transform.position = transform.position;
            newBackgroundTile.transform.rotation = transform.rotation;
            newBackgroundTile.SetActive(true);
        }
    }
}
