using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefaps;
    public GameObject PowerUpPrefaps;
    private float spawnRange = 9;
    public int enemyCount;
    public int enemyVawe;
    private void Start()
    {
        Instantiate(PowerUpPrefaps, GenerateSpawnPosition(), PowerUpPrefaps.transform.rotation);
    }
    private void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if(enemyCount == 0)
        {
            enemyVawe++;
            SpawnEnemyWave(enemyVawe);
            Instantiate(PowerUpPrefaps, GenerateSpawnPosition(), PowerUpPrefaps.transform.rotation);
        } 
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefaps, GenerateSpawnPosition(), enemyPrefaps.transform.rotation);
        }
    }
}
