using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public static int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1) && !GetKeyL3.isSolving)
        {
            selectedWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && !GetKeyL3.isSolving)
        {
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon) { selectWeapon(); }
    }

    private void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
