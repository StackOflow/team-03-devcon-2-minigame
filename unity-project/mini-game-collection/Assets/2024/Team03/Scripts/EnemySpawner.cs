using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject Enemy;
        [SerializeField] int enemyCount;
        [SerializeField] int maxEnemyCount;
        [SerializeField] float timeBetweenSpawns;
        [SerializeField] float randomXPosition;
        [SerializeField] float positionY;
        [SerializeField] float positionZ;
        [SerializeField] float rotationY;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(WaveSpawn());
            }
        }

        IEnumerator WaveSpawn()
        {
            while (enemyCount < maxEnemyCount) 
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-randomXPosition, randomXPosition), positionY, positionZ);
                Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                Instantiate(Enemy, randomSpawnPosition, rotSpawnPosition);
                yield return new WaitForSeconds(timeBetweenSpawns);
                enemyCount += 1;
            }
            if (enemyCount >= maxEnemyCount)
            {
                enemyCount = 0;
            }
        }
    }
}
