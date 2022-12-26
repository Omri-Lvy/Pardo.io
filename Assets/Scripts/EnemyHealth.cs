using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public const int MAX_HEALTH = 100;
    public int currentHealth;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    private void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0 && isDead == false)
        {
            Debug.Log("DEAD: " + currentHealth);
            gameObject.GetComponent<Animator>().Play("Dying");
            isDead = true;
        }
    }

    // Implemenet a function to check if enemy was hit by shot, then call TakeDamage to update health.
    private void GotHit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // GotHit();
    }
}
