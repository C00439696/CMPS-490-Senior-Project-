using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public GameObject healthPack;
    public AudioSource healthUp;

    private UIManager uIManager;
    private bool isGaining = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (ThridPeraonShooterController.health < 100)
            {
                ThridPeraonShooterController.health += 25;
                if (ThridPeraonShooterController.health > 100)
                {
                   ThridPeraonShooterController.health = 100;
                }
                if (!isGaining)
                {
                    healthUp.Play();
                    isGaining = true;
                }
                else
                {
                    healthUp.Stop();
                    isGaining = false;
                }
                isGaining = false;
                healthPack.SetActive(false);
            }
        }

    }
}
