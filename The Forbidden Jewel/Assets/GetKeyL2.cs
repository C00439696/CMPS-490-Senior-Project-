using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class GetKeyL2 : MonoBehaviour
{
    [SerializeField] GameObject key;
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public static int enemyCount;

    private void OnTriggerEnter(Collider other)
    {
        UIManager.numOfEnemies = 3;
        if (other.gameObject.layer == 6)
        {
            ThridPeraonShooterController.key = 1;
            Destroy(key);
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)
        {
            xPos = Random.Range(6, 35);
            zPos = Random.Range(1, 21);
            Instantiate(Enemy, new Vector3(xPos, 0.22f, zPos), Quaternion.identity);
            Enemy.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
            if (enemyCount == 5)
            {
                Destroy(gameObject);
            }
        }
    }
}
