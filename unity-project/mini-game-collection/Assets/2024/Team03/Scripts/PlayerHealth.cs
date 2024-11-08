using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 10f;
        public float currentHealth;    // The current health of the player

        public Animator hurtScreenAnim;

        void Start()
        {
            currentHealth = maxHealth;  // Set current health to the maximum health
        }

        public void TakeDamage(float damage)
        {
            Debug.Log(currentHealth);
            hurtScreenAnim.SetBool("isHurt", true);

            // Reduce current health by damage
            currentHealth -= damage;

            // Ensure health doesn't go below zero
            if (currentHealth <= 0f)
            {
                Die();
            }
            else
            {
                StartCoroutine(ResetHealthState());
            }
        }

        // Method called when the player's health reaches zero
        private void Die()
        {
            Debug.Log("You have died!");
            StartCoroutine(ResetHealthState());
        }

        IEnumerator ResetHealthState()
        {
            yield return new WaitForSeconds(0.2f);
            hurtScreenAnim.SetBool("isHurt", false);
        }
    }
}
