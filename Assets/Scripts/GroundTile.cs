using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject relicPrefab;
    bool obstaclesSpawned = false; // flag to track if obstacles have been spawned

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        Invoke("SpawnObstacle", 5f); // Delay obstacle spawning by 5 seconds
        Invoke("SpawnRelic", 5f);
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // Destroy game object 2s later
    }

    void SpawnObstacle() {
        // Check if obstacles have already been spawned
        if (!obstaclesSpawned) {
            // Random point to spawn
            int obstacleSpawnIndex = Random.Range(2, 5); // Random number between 2 and 4
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform; // Return transformed component of the 3 spawn points
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); // Obstacle destroyed when tile is destroyed
            obstaclesSpawned = true; // Set flag to true to indicate obstacles have been spawned
        }
    }

    void SpawnRelic () {
        GameObject relic = Instantiate(relicPrefab, transform); //spawn and attach it to parent transofrm so it is removed if passed
        relic.transform.position = getPositionOfRelic(GetComponent<Collider>()); //generate randomly on the path

    }

    Vector3 getPositionOfRelic(Collider path) {
        float xPosition = Random.Range(path.bounds.min.x, path.bounds.max.x); //get a point on the path in the x axis
        float zPosition = Random.Range(path.bounds.min.z, path.bounds.max.z); //get a point on the path in the zy axis
    
        return new Vector3(xPosition, 1, zPosition);
    }


}
