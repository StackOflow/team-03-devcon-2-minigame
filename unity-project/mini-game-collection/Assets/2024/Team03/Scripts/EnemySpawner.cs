using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace MiniGameCollection.Games2024.Team03
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject Enemy;
        public GameObject winScreen;

        [SerializeField] int enemyCountW1;
        [SerializeField] int maxEnemyCountW1;
        [SerializeField] float timeBetweenSpawnsW1;
        private bool wave2Trigger = false;
        [SerializeField] int enemyCountW2;
        [SerializeField] int maxEnemyCountW2;
        [SerializeField] float timeBetweenSpawnsW2;
        private bool wave3Trigger = false;
        [SerializeField] int enemyCountW3;
        [SerializeField] int maxEnemyCountW3;
        [SerializeField] float timeBetweenSpawnsW3;

        [SerializeField] float positionY;
        [SerializeField] float positionZ;
        [SerializeField] float positionX;
        [SerializeField] float minPositionX;
        [SerializeField] float maxPositionX;

        // Reference to the TextMeshProUGUI component
        public TextMeshProUGUI countdownText;
        // The starting time for the countdown
        public float timeRemaining = 60f;

        void Start () 
        {
            StartCoroutine(WaveSpawn1());
        }

        private void Update()
        {
            CountDown();

            if (timeRemaining <= 45f && !wave2Trigger)
            {
                wave2Trigger = true;
                Debug.Log("Wave 2");
                StartCoroutine(WaveSpawn2());
            }
            else if (timeRemaining <= 25f && !wave3Trigger)
            {
                wave3Trigger = true;
                Debug.Log("Wave 3");
                StartCoroutine(WaveSpawn3());
            }

            if (timeRemaining <= 0f)
            {
                winScreen.SetActive(true);
            }
        }

        void CountDown()
        {
            // Only update if time is remaining
            if (timeRemaining > 0f)
            {
                // Decrease the time by the amount of time passed since the last frame
                timeRemaining -= Time.deltaTime;

                // Update the displayed text
                int seconds = Mathf.CeilToInt(timeRemaining);
                countdownText.text = seconds.ToString();
            }
        }

        IEnumerator WaveSpawn1()
        {
            while (enemyCountW1 < maxEnemyCountW1) 
            {
                positionX = Random.Range(minPositionX, maxPositionX);
                Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                Instantiate(Enemy, randomSpawnPosition, rotSpawnPosition);
                yield return new WaitForSeconds(timeBetweenSpawnsW1);
                enemyCountW1 += 1;
            }
            if (enemyCountW1 >= maxEnemyCountW1)
            {
                enemyCountW1 = 0;
            }
        }
        IEnumerator WaveSpawn2()
        {
            while (enemyCountW2 < maxEnemyCountW2)
            {
                positionX = Random.Range(minPositionX, maxPositionX);
                Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                Instantiate(Enemy, randomSpawnPosition, rotSpawnPosition);
                yield return new WaitForSeconds(timeBetweenSpawnsW2);
                enemyCountW2 += 1;
            }
            if (enemyCountW2 >= maxEnemyCountW2)
            {
                enemyCountW2 = 0;
            }
        }
        IEnumerator WaveSpawn3()
        {
            while (enemyCountW3 < maxEnemyCountW3)
            {
                positionX = Random.Range(minPositionX, maxPositionX);
                Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                Instantiate(Enemy, randomSpawnPosition, rotSpawnPosition);
                yield return new WaitForSeconds(timeBetweenSpawnsW3);
                enemyCountW3 += 1;
            }
            if (enemyCountW3 >= maxEnemyCountW3)
            {
                enemyCountW3 = 0;
            }
        }
    }
}
