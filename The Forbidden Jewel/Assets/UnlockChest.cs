using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockChest : MonoBehaviour
{
    public string theAnswer;
    public TMP_InputField inputField;
    public TextMeshProUGUI textDisplay;
    public GameObject textBox;
    public GameObject solver;
    public int attempts = 3;
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public static int enemyCount;

    public void StoreName()
    {
        theAnswer = inputField.text;

        if (theAnswer != "490")
        {
            inputField.text = "";
            attempts--;
            textDisplay.text = "This was created for CMPS ____: Senior Project?\nFill in the blank to unlock the chest?\nYou have " + attempts + " attempts left or you will be eliminated!";
            if (attempts < 0)
            {
                solver.GetComponent<ThridPeraonShooterController>().TakeDamage(100);

            }
        }
        else
        {
            Time.timeScale = 1f;
            GetKeyL3.isSolving = false;
            Cursor.lockState = CursorLockMode.Locked;
            UIManager.numOfEnemies = 5;
            Cursor.visible = false;
            ThridPeraonShooterController.key = 1;
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(6, 35);
            zPos = Random.Range(1, 21);
            Instantiate(Enemy, new Vector3(xPos, 0.22f, zPos), Quaternion.identity);
            Enemy.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
            if (enemyCount == 5)
            {
                textBox.SetActive(false);
            }
        }
    }
}
