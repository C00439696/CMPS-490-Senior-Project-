using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            // Hit Target
            Debug.Log("Hit Target");
        }
        else
        {
            // Hit something else
            Debug.Log("Didn't hit Target");
        }
        Destroy(gameObject);
    }
}
