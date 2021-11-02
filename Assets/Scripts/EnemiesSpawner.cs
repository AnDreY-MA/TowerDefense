using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 5f)]private float spawnInterval;

    [SerializeField] private EnemyMovement enemyPrefab;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.transform);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
