using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 2f;

    public Vector3 center;
    public Vector3 size;

    public int spawnCount = 1;      // 1回に出す数
    public float increaseTime = 10f; // 増加間隔

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(IncreaseSpawnCount());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 randomPos = new Vector3(
                    Random.Range(-size.x / 2, size.x / 2),
                    0,
                    Random.Range(-size.z / 2, size.z / 2)
                );

                Vector3 spawnPos = center + randomPos;

                Instantiate(prefab, spawnPos, Quaternion.identity);
            }

            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator IncreaseSpawnCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseTime);

            spawnCount++;

            Debug.Log("スポーン数増加: " + spawnCount);
        }
    }
}