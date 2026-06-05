using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 2f;

    public Vector3 center; // ”ÍˆÍ‚Ì’†S
    public Vector3 size;   // ”ÍˆÍ‚ÌL‚³

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-size.x / 2, size.x / 2),
                0,
                Random.Range(-size.z / 2, size.z / 2)
            );

            Vector3 spawnPos = center + randomPos;

            Instantiate(prefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}