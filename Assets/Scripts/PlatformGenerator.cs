using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    private int platformSelector;
    //private float platformWidth;
    private float minimumHeight;
    private float maximumHeight;
    private float heightDifference;
    private float[] platformWidths;
    private StarGenerator starGenerator;

    public GameObject newPlatform;
    //public GameObject[] platforms;
    public float distanceBetweenPlatforms;
    public float distanceBeetweenPlatformsMin;
    public float distanceBetweenPlatformsMax;
    public float maximumHeightDiffrence;
    public float randomStarThreshold;
    public ObjectPooler[] objectPools;
    public Transform generationPoint;
    public Transform maximumHeightPoint;
    

    void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[objectPools.Length];

        for (int i = 0; i < objectPools.Length; i++)
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

        minimumHeight = transform.position.y;
        maximumHeight = maximumHeightPoint.position.y;

        starGenerator = FindObjectOfType<StarGenerator>();

	}
	
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweenPlatforms = Random.Range(distanceBeetweenPlatformsMin, distanceBetweenPlatformsMax);

            platformSelector = Random.Range(0, objectPools.Length);

            heightDifference = transform.position.y + Random.Range(maximumHeightDiffrence, -maximumHeightDiffrence);

            if (heightDifference > maximumHeight)
                heightDifference = maximumHeight;
            if (heightDifference < minimumHeight)
                heightDifference = minimumHeight;

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2 ) + distanceBetweenPlatforms, heightDifference, transform.position.z);
            //Instantiate(thePlatform, transform.position, transform.rotation);

            newPlatform = objectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 100f) < randomStarThreshold)
                starGenerator.SpawnStars(new Vector3(transform.position.x,transform.position.y + 1f, transform.position.z));

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
