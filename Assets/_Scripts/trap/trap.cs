using System;
using UnityEngine;

public class trap : MonoBehaviour
{
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.ChangeHealth(-10000);
        }
    }
    
}
