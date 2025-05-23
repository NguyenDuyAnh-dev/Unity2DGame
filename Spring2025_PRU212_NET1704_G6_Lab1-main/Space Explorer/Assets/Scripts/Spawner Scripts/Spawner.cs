using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private BoxCollider2D box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(SpawnerEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerEnemy()
    {
        int currentLevel = GameManager.Instance.GetLevel();
        float spawnRate = Mathf.Clamp(4f - currentLevel * 0.3f, 0.5f, 4f);

        yield return new WaitForSeconds(Random.Range(1f, 4f));

        int enemiesToSpawn = 1 + (currentLevel / 3); // Each level, spawn 1 more enemy
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float minX = transform.position.x - (box.bounds.size.x / 2f);
            float maxX = transform.position.x + (box.bounds.size.x / 2f);
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(minX, maxX);

            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
            Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
        }

        StartCoroutine(SpawnerEnemy()); // Restart coroutine
    }
}
