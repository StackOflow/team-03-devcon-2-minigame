using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class HostageMovement : MonoBehaviour
    {
        public float speed; // Speed at which the GameObject moves forward
        public float minSpeed = 2f;
        public float maxSpeed = 4f;
        private Vector3 forward = new Vector3(-1, 0, 0);

        [SerializeField] GameObject Hostage;
        [SerializeField] int hostageCount;
        [SerializeField] int maxHostageCount;
        [SerializeField] float timeBetweenSpawns;
        [SerializeField] float randomZPosition;
        [SerializeField] float positionY;
        [SerializeField] float positionX;
        [SerializeField] float rotationY;

        private void Start()
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(WaveSpawn());
            }
            // Move the GameObject forward along its local z-axis
            transform.Translate(forward * speed * Time.deltaTime);
        }

        IEnumerator WaveSpawn()
        {
            while (hostageCount < maxHostageCount)
            {
                Vector3 randomSpawnPosition = new Vector3(positionX, positionY, Random.Range(-randomZPosition, randomZPosition));
                Quaternion rotSpawnPosition = new Quaternion(0, 180, 0, 0);
                Instantiate(Hostage, randomSpawnPosition, rotSpawnPosition);
                yield return new WaitForSeconds(timeBetweenSpawns);
                hostageCount += 1;
            }
            if (hostageCount >= maxHostageCount)
            {
                hostageCount = 0;
            }
        }
    }
}
