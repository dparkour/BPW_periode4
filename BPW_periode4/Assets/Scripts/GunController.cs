using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController Instance;

    public GameManager gameManager;

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public int MaxAmmo = 20;

    public int Ammo;

    public bool powered;

    public SkinnedMeshRenderer mesh;

    public Color32 PowerUpColor;

    public Color32 standardColor;


    public ParticleSystem ParticleEffect;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        Ammo = MaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring && !gameManager.IsPaused)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                if(Ammo > 0 && !powered)
                {
                    Fire();
                }
                else if(powered)
                {
                    TripleFire();
                }
                else
                {
                    //Play empty gun sound
                }

            }
        }
        else
        {
            shotCounter = 0;
        }

    }

    void Fire()
    {
        Ammo--;
        shotCounter = timeBetweenShots;
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
        newBullet.speed = bulletSpeed;
    }

    void TripleFire()
    {
        shotCounter = timeBetweenShots;
        for(int i = 0; i < 3; i++)
        {
            BulletController newBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(firePoint.rotation.eulerAngles.x, firePoint.rotation.eulerAngles.y - 15 + (i * 15),firePoint.rotation.eulerAngles.z)) as BulletController;
            newBullet.speed = bulletSpeed;

        }
    }

    public void PowerUp(float powerTime)
    {
        StopAllCoroutines();
        StartCoroutine(PowerUpStart(powerTime));
    }

    IEnumerator PowerUpStart(float powerTime)
    {
        Material material = mesh.material;
        material.color = PowerUpColor;
        powered = true;
        ParticleEffect.Play();
        yield return new WaitForSeconds(powerTime);
        ParticleEffect.Stop();
        powered = false;
        material.color = standardColor;

    }
}
