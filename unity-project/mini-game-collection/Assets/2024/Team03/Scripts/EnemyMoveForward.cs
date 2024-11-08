using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class EnemyMoveForward : MonoBehaviour
    {
        public float speed = 5f; // Speed at which the GameObject moves forward
        private Vector3 forward = new Vector3(0, 0, -1);

        void Update()
        {
            // Move the GameObject forward along its local z-axis
            transform.Translate(forward * speed * Time.deltaTime);
        }
    }
}
