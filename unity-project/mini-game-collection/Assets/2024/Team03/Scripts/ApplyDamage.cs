using MiniGameCollection.Games2024.Team03;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class ApplyDamage : MonoBehaviour
    {
        public float detectionRange = 10f;  // Maximum distance at which the enemy can detect the player
        public float damageAmount = 10f;    // Amount of damage to deal when the player is detected
        public float damageInterval = 1f;   // Time interval between damage applications

        private float nextDamageTime = 0f;  // Timer to track damage intervals

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
            if (Physics.Raycast(ray, out hit, detectionRange, playerLayer))
            {
                    // Only apply damage if enough time has passed
                    if (Time.time >= nextDamageTime)
                    {
                        // Apply damage to the player
                        PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                        if (playerHealth != null)
                        {
                            playerHealth.TakeDamage((int)damageAmount);
                            nextDamageTime = Time.time + damageInterval; // Reset the damage timer
                        }
                    }
                
            }
        }
    }
}
