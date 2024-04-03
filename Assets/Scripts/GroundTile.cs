using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject relicPrefab;
    public GameObject powerUpPrefab;
    bool obstaclesSpawned = false; // flag to track if obstacles have been spawned
    bool powerUpSpawned = false;
   

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
      
        Invoke("SpawnObstacle", 5f); // Delay obstacle spawning by 5 seconds
        Invoke("SpawnRelic", 5f);
        Invoke("SpawnPowerUp", 5f);
        
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // Destroy game object 2s later

    }

    void SpawnObstacle()
    {
        // Check if obstacles have already been spawned
        if (!obstaclesSpawned)
        {
            // Random point to spawn
            int obstacleSpawnIndex = Random.Range(2, 5); // Random number between 2 and 4
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform; // Return transformed component of the 3 spawn points
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); // Obstacle destroyed when tile is destroyed
            obstaclesSpawned = true; // Set flag to true to indicate obstacles have been spawned
        }
    }

    void SpawnRelic()
    {
        GameObject relic = Instantiate(relicPrefab, transform); // Spawn and attach it to parent transform so it is removed if passed
        relic.transform.position = getPositionOnPath(GetComponent<Collider>()); // Generate randomly on the path
    }


    Vector3 getPositionOnPath(Collider path)
    {
        float xPosition = Random.Range(path.bounds.min.x, path.bounds.max.x); // Get a point on the path in the x-axis
        float zPosition = Random.Range(path.bounds.min.z, path.bounds.max.z); // Get a point on the path in the z-axis

        return new Vector3(xPosition, 1, zPosition);
    }

    void SpawnPowerUp()
    {
        if (!powerUpSpawned)
        {
        float initialZ  = 103.52313f;
        float zIncrement = 300f;
        
        for (int i = 0; i < 100; i++) // Spawn 100 power-ups
        {       
            Vector3 powerUpPosition = new Vector3(0.6f, 0.6f, initialZ + i * zIncrement);
            Instantiate(powerUpPrefab, powerUpPosition, Quaternion.identity);
        }
       
        
        
        powerUpSpawned = true;
        }
    }
}
