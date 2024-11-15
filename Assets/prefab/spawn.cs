using System.Collections;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của kẻ địch
    public float spawnRadius = 5f; // Phạm vi sinh kẻ địch mới
    public float spawnInterval = 5f; // Khoảng thời gian sinh kẻ địch mới

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Xác định vị trí ngẫu nhiên trong phạm vi spawnRadius
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Tạo một kẻ địch mới tại vị trí spawnPosition
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
