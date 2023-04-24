using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyL4 : MonoBehaviour
{
    [SerializeField] GameObject key;
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        UIManager.numOfEnemies = 1;
        if (other.gameObject.layer == 6)
        {
            ThridPeraonShooterController.key = 1;
            Destroy(key);
            Enemy.SetActive(true);
            Destroy(gameObject);
        }
    }
}
