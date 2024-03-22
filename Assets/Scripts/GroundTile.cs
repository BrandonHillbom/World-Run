using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    bool obstaclesSpawned = false; // flag to track if obstacles have been spawned

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        Invoke("SpawnObstacle", 5f); // Delay obstacle spawning by 5 seconds
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
}
