using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniGameCollection.Games2024.Team03
{
    public class HostageSpawner : MonoBehaviour
    {
        [SerializeField] GameObject Hostage;
        [SerializeField] int hostageCountW1;
        [SerializeField] int maxHostageCountW1;
        [SerializeField] float timeBetweenSpawnsW1;
        private bool wave2Trigger = false;
        [SerializeField] int hostageCountW2;
        [SerializeField] int maxHostageCountW2;
        [SerializeField] float timeBetweenSpawnsW2;
        private bool wave3Trigger = false;
        [SerializeField] int hostageCountW3;
        [SerializeField] int maxHostageCountW3;
        [SerializeField] float timeBetweenSpawnsW3;

        [SerializeField] float positionZ;
        [SerializeField] float maxPositionZ;
        [SerializeField] float minPositionZ;
        [SerializeField] float positionY;
        [SerializeField] float positionX;

        [SerializeField] float positionZ_R;
        [SerializeField] float maxPositionZ_R;
        [SerializeField] float minPositionZ_R;
        [SerializeField] float positionY_R;
        [SerializeField] float positionX_R;

        private int screenSides = 0;
        // The starting time for the countdown
        public float timeRemaining = 60f;

        private void Start()
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
        }

        void CountDown()
        {
            // Only update if time is remaining
            if (timeRemaining > 0f)
            {
                // Decrease the time by the amount of time passed since the last frame
                timeRemaining -= Time.deltaTime;
            }
        }
        IEnumerator WaveSpawn1()
        {
            while (hostageCountW1 < maxHostageCountW1)
            {
                if (screenSides == 0)
                {
                    positionZ = Random.Range(minPositionZ, maxPositionZ);
                    Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                    Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition, rotSpawnPosition);
                    screenSides++;
                }
                else if (screenSides == 1) 
                {
                    positionZ_R = Random.Range(minPositionZ_R, maxPositionZ_R);
                    Vector3 randomSpawnPosition_R = new Vector3(positionX_R, positionY_R, positionZ_R);
                    Quaternion rotSpawnPosition_R = new Quaternion(0, 0, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition_R, rotSpawnPosition_R);
                    screenSides--;
                }
                yield return new WaitForSeconds(timeBetweenSpawnsW1);
                hostageCountW1 += 1;
            }
            if (hostageCountW1 >= maxHostageCountW1)
            {
                hostageCountW1 = 0;
            }
        }

        IEnumerator WaveSpawn2()
        {
            while (hostageCountW2 < maxHostageCountW2)
            {
                if (screenSides == 0)
                {
                    positionZ = Random.Range(minPositionZ, maxPositionZ);
                    Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                    Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition, rotSpawnPosition);
                    screenSides++;
                }
                else if (screenSides == 1)
                {
                    positionZ_R = Random.Range(minPositionZ_R, maxPositionZ_R);
                    Vector3 randomSpawnPosition_R = new Vector3(positionX_R, positionY_R, positionZ_R);
                    Quaternion rotSpawnPosition_R = new Quaternion(0, 0, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition_R, rotSpawnPosition_R);
                    screenSides--;
                }
                yield return new WaitForSeconds(timeBetweenSpawnsW2);
                hostageCountW2 += 1;
            }
            if (hostageCountW2 >= maxHostageCountW2)
            {
                hostageCountW2 = 0;
            }
        }

        IEnumerator WaveSpawn3()
        {
            while (hostageCountW3 < maxHostageCountW3)
            {
                if (screenSides == 0)
                {
                    positionZ = Random.Range(minPositionZ, maxPositionZ);
                    Vector3 randomSpawnPosition = new Vector3(positionX, positionY, positionZ);
                    Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition, rotSpawnPosition);
                    screenSides++;
                }
                else if (screenSides == 1)
                {
                    positionZ_R = Random.Range(minPositionZ_R, maxPositionZ_R);
                    Vector3 randomSpawnPosition_R = new Vector3(positionX_R, positionY_R, positionZ_R);
                    Quaternion rotSpawnPosition_R = new Quaternion(0, 0, 0, 0);
                    Instantiate(Hostage, randomSpawnPosition_R, rotSpawnPosition_R);
                    screenSides--;
                }
                yield return new WaitForSeconds(timeBetweenSpawnsW3);
                hostageCountW3 += 1;
            }
            if (hostageCountW3 >= maxHostageCountW3)
            {
                hostageCountW3 = 0;
            }
        }
    }
}
