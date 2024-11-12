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

        private void Start()
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }
        void Update()
        {
            // Move the GameObject forward along its local z-axis
            transform.Translate(forward * speed * Time.deltaTime);
        }
    }
}
