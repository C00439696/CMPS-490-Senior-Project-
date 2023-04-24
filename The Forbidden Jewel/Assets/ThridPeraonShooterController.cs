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
    [SerializeField] private int maxAmmo = 12;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Vector3 aimDir;
    private bool isAiming;
    public static int key = 0;
    public static int currentAmmo;

    [SerializeField] private AudioSource shoots;
    [SerializeField] private AudioSource outOFBullets;
    [SerializeField] private AudioSource axeSwing;

    private bool isShooting = false;
    private bool isOutOfBullets = false;
    private bool isAxeSwinging = false;

    public ProgressBar Pb;
    public int health = 100;

    private UIManager uIManager;
    public GameObject gameOver;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();

        currentAmmo = maxAmmo;
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        Pb.BarValue = health;
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
            aimVirtualCamera.gameObject.SetActive(true);
            isAiming = true;
            thirdPersonController.SetSensitivity(aimSensitivty);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if (starterAssetsInputs.shoot && WeaponSwitching.selectedWeapon == 0 && currentAmmo > 0 && isAiming && !PauseMenu.isPaused && !GetKeyL3.isSolving)
            {
                aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                GameObject projectile = Instantiate(bullet, spawnBulletPosition.transform.position, spawnBulletPosition.transform.rotation);
                if (!isShooting && !isOutOfBullets && !isAxeSwinging)
                {
                    shoots.Play();
                    isShooting = true;
                }
                else
                {
                    shoots.Stop();
                    isShooting = false;
                }
                isShooting = false;

                projectile.GetComponent<Rigidbody>().AddForce(aimDir * 120, ForceMode.VelocityChange);
                currentAmmo--;
                uIManager.UpdateAmmo(currentAmmo);
                starterAssetsInputs.shoot = false;
            }
            else
            {
                if (!isShooting && !isOutOfBullets && !isAxeSwinging)
                {
                    outOFBullets.Play();
                    isOutOfBullets = true;
                }
                else
                {
                    outOFBullets.Stop();
                    isOutOfBullets = false;
                }
                isOutOfBullets = false;
            }
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            isAiming = false;
            thirdPersonController.SetSensitivity(normalSensitivty);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.attack && WeaponSwitching.selectedWeapon == 1)
        {
            aimDir = (mouseWorldPosition - axeTipPosition.position).normalized;
            animator.SetTrigger("attack");
            if (!isShooting && !isOutOfBullets && !isAxeSwinging)
            {
                axeSwing.Play();
                isAxeSwinging = true;
            }
            else
            {
                axeSwing.Stop();
                isOutOfBullets = false;
            }
            isOutOfBullets = false;

            starterAssetsInputs.attack = false;
        }

        if (currentAmmo > 12)
        {
            currentAmmo = 12;
        }
    }

    public int getKey()
    {
        return key;
    }

    public void setKey(int k)
    {
        key = k;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver.SetActive(true);
        }
    }
}
