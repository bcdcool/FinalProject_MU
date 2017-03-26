using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public _PlayerHealth playerHealth;
    public GameObject enemy;
    public float initSpawnTime = 3f; 
    public float spawnTime = 3f;
    public GameObject[] spawnPoints;

    public int enemiesPerSpawnMin;
    public int enemiesPerSpawnMax;

    void Start ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        Invoke("Spawn", initSpawnTime);
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex;// = Random.Range (0, spawnPoints.Length);
        int enemiesPerSpawn = Random.Range(enemiesPerSpawnMin, enemiesPerSpawnMax);

        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].GetComponent<Transform>().position, spawnPoints[spawnPointIndex].GetComponent<Transform>().rotation);
        }

    }
}
