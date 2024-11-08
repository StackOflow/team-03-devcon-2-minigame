using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;    // The current health of the enemy

    public Animator enemyAnim;

    void Start()
    {
        currentHealth = maxHealth;  // Set current health to the maximum health
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
