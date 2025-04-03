using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefaps;
    private float spawnRange = 9;
    private void Start()
    {
       Instantiate(enemyPrefaps, GenerateSpawnPosition() , enemyPrefaps.transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
