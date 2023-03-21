using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThridPeraonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivty;
    [SerializeField] private float aimSensitivty;
    [SerializeField] private LayerMask aimColliderMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform axeTipPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Vector3 aimDir;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2F);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        if (starterAssetsInputs.aimGun && WeaponSwitching.selectedWeapon == 0)
        {
            aimVirtualCamera.gameObject.SetActive(true); ;
            thirdPersonController.SetSensitivity(aimSensitivty);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if (starterAssetsInputs.shoot && WeaponSwitching.selectedWeapon == 0)
            {
                aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                GameObject projectile = Instantiate(bullet, spawnBulletPosition.transform.position, spawnBulletPosition.transform.rotation);                
                projectile.GetComponent<Rigidbody>().AddForce(aimDir * 120, ForceMode.VelocityChange);
                starterAssetsInputs.shoot = false;
            }
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivty);
            thirdPersonController.SetRotateOnMove(true);
            //animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.attack && WeaponSwitching.selectedWeapon == 1)
        {
            aimDir = (mouseWorldPosition - axeTipPosition.position).normalized;
            animator.SetTrigger("attack");
            /*Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies) {
                enemy.GetComponent<Enemy>().TakeDamage(40);
            }*/

            starterAssetsInputs.attack = false;
        }
    }

    /*void OnDrawGizmosSelected()
    {
        if (attackRange == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
