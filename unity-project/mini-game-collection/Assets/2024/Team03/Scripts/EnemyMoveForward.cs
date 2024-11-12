using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class EnemyMoveForward : MonoBehaviour
    {
        public float speed = 5f; // Speed at which the GameObject moves forward
        private Vector3 forward = new Vector3(0, 0, 1);
        private Vector3 pause = new Vector3(0, 0, 0);

        private Transform player;           // Reference to the player's position 
        public LayerMask playerLayer;

        private void Start()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // If player object is found, store its transform
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        void Update()
        {
            if (player == null)
            {
                return;
            }

            // Cast a ray from the enemy's position to the player
            Vector3 directionToPlayer = player.position - transform.position;
            Ray ray = new Ray(transform.position, directionToPlayer);
            RaycastHit hit;

            // Perform the raycast to see if the player is within the detection range
            if (Physics.Raycast(ray, out hit, 0.7f, playerLayer))
            {
                transform.Translate(pause);
            }
            else
            {
                // Move the GameObject forward along its local z-axis
                transform.Translate(forward * speed * Time.deltaTime);
            }
        }




    }
}
