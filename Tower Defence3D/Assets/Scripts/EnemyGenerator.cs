using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private int enemyCount = 5;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    private int spawnCount;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5, spawnDelay);
        spawnCount = 0;
    }

    private void SpawnEnemy()
    {
        spawnCount++;
        if (spawnCount > enemyCount) return;
        
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
