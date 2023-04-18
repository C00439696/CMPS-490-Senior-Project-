using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] GameObject key;
    ThridPeraonShooterController ThridPeraonShooter;
    private StarterAssetsInputs starterAssetsInputs;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            ThridPeraonShooterController.key = 1;
            Destroy(key);
            Destroy(gameObject);
        }
    }
}
