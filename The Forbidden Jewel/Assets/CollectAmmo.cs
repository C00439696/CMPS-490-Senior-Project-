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
    private bool isReloading = false;


    private void OnTriggerEnter(Collider other)
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (other.gameObject.layer == 6)
        {
            if (ThridPeraonShooterController.currentAmmo < 12)
            {
                ThridPeraonShooterController.currentAmmo += 5;
                if (ThridPeraonShooterController.currentAmmo > 12)
                {
                    ThridPeraonShooterController.currentAmmo = 12;
                }
                    uIManager.UpdateAmmo(ThridPeraonShooterController.currentAmmo);
                if (!isReloading)
                {
                    moreAmmo.Play();
                    isReloading = true;
                }
                else
                {
                    moreAmmo.Stop();
                    isReloading = false;
                }
                isReloading = false;
                theAmmo.SetActive(false);
            }
        }
        
    }
}
