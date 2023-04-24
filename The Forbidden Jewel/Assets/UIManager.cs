using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject ammoTextGun;
    [SerializeField] private GameObject ammoTextKnife;
    [SerializeField] private GameObject GetKey;
    [SerializeField] private GameObject Enemies;
    [SerializeField] private GameObject Leave;

    public static int numOfEnemies = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (WeaponSwitching.selectedWeapon == 0)
        {
            ammoTextKnife.SetActive(false);
            ammoTextGun.SetActive(true);
        }
        else if (WeaponSwitching.selectedWeapon == 1)
        {
            ammoTextGun.SetActive(false);
            ammoTextKnife.SetActive(true);
        }

        if (ThridPeraonShooterController.key == 0)
        {
            GetKey.SetActive(true);
        }
        
        if(ThridPeraonShooterController.key == 1)
        {
            GetKey.SetActive(false);
            Enemies.SetActive(true);
        }

        if (OpenDoor.enemieskilled == numOfEnemies)
        {
            Enemies.SetActive(false);
            Leave.SetActive(true);
        }
    }

    public void UpdateAmmo(int count)
    {
        if (WeaponSwitching.selectedWeapon == 0)
        {
            ammoTextGun.GetComponent<Text>().text = "Ammo: " + count + "/12";
        }
    }

    public void UpdateEnemies(int count)
    {
        Enemies.GetComponent<Text>().text = "Eliminate all enemies before leaving: " + count + "/" + numOfEnemies;
    }
}
