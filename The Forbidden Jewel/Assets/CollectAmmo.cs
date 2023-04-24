using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAmmo : MonoBehaviour
{
    public GameObject theAmmo;
    public GameObject ammoDisplay;
    public AudioSource moreAmmo;

    private UIManager uIManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ThridPeraonShooterController.currentAmmo < 12)
            {
                ThridPeraonShooterController.currentAmmo += 5;
                uIManager.UpdateAmmo(ThridPeraonShooterController.currentAmmo);
                moreAmmo.Play();
                theAmmo.SetActive(false);
            }
        }
        
    }
}
