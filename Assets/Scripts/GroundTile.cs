
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); //destroy game object 2s later
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() {
        //random point to spawn
        int obstacleSpawnIndex = Random.Range(2,5); //random number between 2 and 4

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform; //return transofrmed component of the 3 spawn points

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform); //obstacle destroyed when tile is destroyed
    }
}
