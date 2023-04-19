using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] GameObject key;
    ThridPeraonShooterController ThridPeraonShooter;
    private StarterAssetsInputs starterAssetsInputs;
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public static int enemyCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            ThridPeraonShooterController.key = 1;
            Destroy(key);
            StartCoroutine(EnemyDrop());
            Destroy(gameObject);
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
