using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.Games2024.Team03
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 10;
        public int currentHealth;    // The current health of the player

        public Animator hurtScreenAnim;

        public HealthBar healthBar;

        void Start()
        {
            currentHealth = maxHealth;  // Set current health to the maximum health
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(currentHealth);
            hurtScreenAnim.SetBool("isHurt", true);

            // Reduce current health by damage
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

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
            SceneManager.LoadScene("2024-Team03-GameOver");
            StartCoroutine(ResetHealthState());
        }

        IEnumerator ResetHealthState()
        {
            yield return new WaitForSeconds(0.2f);
            hurtScreenAnim.SetBool("isHurt", false);
        }
    }
}
