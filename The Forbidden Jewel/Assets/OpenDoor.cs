using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    ThridPeraonShooterController ThridPeraonShooter;

    [SerializeField] GameObject switchWithoutKey;
    [SerializeField] GameObject switchWithKey;

    public static int enemieskilled = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (ThridPeraonShooterController.key == 1 && enemieskilled == 5)
        {
            if (other.tag == "Player")
            {
                switchWithoutKey.SetActive(false);
                switchWithKey.SetActive(true);
                SceneManager.LoadScene("Level 2");
            }

        }
    }
}
