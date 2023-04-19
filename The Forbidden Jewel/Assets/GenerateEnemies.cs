using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public static int enemyCount;

    // Start is called before the first frame update
    void Update()
    {
        if (ThridPeraonShooterController.key == 1)
        {
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 1)
        {
            xPos = Random.Range(6, 35);
            zPos = Random.Range(1, 21);
            Instantiate(Enemy, new Vector3(xPos, 0.22f, zPos), Quaternion.identity);
            Enemy.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
