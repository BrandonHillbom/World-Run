
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject relicPrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnRelics();
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

    void SpawnRelics() {
        int relicCount = 1;
        for (int i = 0; i < relicCount; i++) {
            GameObject relic = Instantiate(relicPrefab, transform); //spawn coin and delete coins with deleted tiles
            relic.transform.position = GetRelicPosition(GetComponent<Collider>());
        }
    }

    Vector3 GetRelicPosition(Collider groundTile) {
        float randomX = Random.Range(groundTile.bounds.min.x, groundTile.bounds.max.x); //generate a random x between the colliders min and max
        float randomZ = Random.Range(groundTile.bounds.min.z, groundTile.bounds.max.z);

        Vector3 relicPosition = new Vector3(randomX, 1, randomZ);
        return relicPosition;
    }
}
