using UnityEngine;

public class StarGenerator : MonoBehaviour {

    public float distanceBetweenStars;
    public ObjectPooler starPool;

    public void SpawnStars(Vector3 startPosition)
    {
        GameObject star1 = starPool.GetPooledObject();
        star1.transform.position = startPosition;
        star1.SetActive(true);

        GameObject star2 = starPool.GetPooledObject();
        star2.transform.position = new Vector3(startPosition.x - distanceBetweenStars, startPosition.y, startPosition.z);
        star2.SetActive(true);

        GameObject star3 = starPool.GetPooledObject();
        star3.transform.position = new Vector3(startPosition.x + distanceBetweenStars, startPosition.y, startPosition.z);
        star3.SetActive(true);
    }
}
