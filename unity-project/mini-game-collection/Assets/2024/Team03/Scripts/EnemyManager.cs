using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class EnemyManager : MonoBehaviour
    {
        public float maxHealth = 10f;
        public float currentHealth;    // The current health of the enemy

        public Animator enemyAnim;

        public float detectionRange = 10f;  // Maximum distance at which the enemy can detect the player
        public int damageAmount = 1;    // Amount of damage to deal when the player is detected
        public float damageInterval = 1f;   // Time interval between damage applications

        private float nextDamageTime = 0f;  // Timer to track damage intervals

        private Transform player;           // Reference to the player's position 
        public LayerMask playerLayer;

        public float speed = 5f; // Speed at which the GameObject moves forward
        private Vector3 forward = new Vector3(0, 0, 1);
        private Vector3 pause = new Vector3(0, 0, 0);

        void Start()
        {
            currentHealth = maxHealth;  // Set current health to the maximum health
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // If player object is found, store its transform
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        void Update()
        {
            MoveForward();
            ApplyDamage();
        }

        void MoveForward()
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

        void ApplyDamage()
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
                        playerHealth.TakeDamage(damageAmount);
                        nextDamageTime = Time.time + damageInterval; // Reset the damage timer
                    }
                }

            }
        }

        public void TakeDamage(float damage)
        {
            // Reduce current health by damage
            currentHealth -= damage;

            // Ensure health doesn't go below zero
            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        // Method called when the enemy's health reaches zero
        private void Die()
        {
            enemyAnim.SetBool("isDead", true);
            Debug.Log(gameObject.name + " has died!");
            StartCoroutine(SetEnemyAnim());
        }

        IEnumerator SetEnemyAnim()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
