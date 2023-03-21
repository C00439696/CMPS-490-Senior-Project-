using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint;

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(40);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackRange == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}