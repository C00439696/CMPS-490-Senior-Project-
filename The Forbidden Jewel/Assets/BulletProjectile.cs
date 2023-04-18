using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 25;  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            // Hit Target
            Debug.Log("Hit Target");
            other.GetComponent<EnemyAi>().TakeDamage(damage);
        }
        else
        {
            // Hit something else
            Debug.Log("Didn't hit Target");
        }
        Destroy(gameObject);
    }
}
