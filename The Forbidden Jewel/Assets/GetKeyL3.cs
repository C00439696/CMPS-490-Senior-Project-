using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class GetKeyL3 : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] private GameObject textBox;
    public static bool isSolving;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Time.timeScale = 0f;
            isSolving = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            textBox.SetActive(true);
            Destroy(gameObject);
        }
    }
}
