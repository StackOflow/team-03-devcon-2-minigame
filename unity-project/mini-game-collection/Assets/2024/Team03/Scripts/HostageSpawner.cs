using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniGameCollection.Games2024.Team03
{
    public class HostageSpawner : MonoBehaviour
    {
        [SerializeField] GameObject Hostage;
        [SerializeField] int hostageCount;
        [SerializeField] int maxHostageCount;
        [SerializeField] float timeBetweenSpawns;

        [SerializeField] float positionZ;
        [SerializeField] float maxPositionZ;
        [SerializeField] float minPositionZ;
        [SerializeField] float positionY;
        [SerializeField] float positionX;
        [SerializeField] float rotationY;

        [SerializeField] float positionZ_R;
        [SerializeField] float maxPositionZ_R;
        [SerializeField] float minPositionZ_R;
        [SerializeField] float positionY_R;
        [SerializeField] float positionX_R;
        [SerializeField] float rotationY_R;

        private int screenSides = 0;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(WaveSpawn());
            }
        }

        IEnumerator WaveSpawn()
        {
            while (hostageCount < maxHostageCount)
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
