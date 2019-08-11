using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public GameObject Ammo;
    public float AmmoChance = 25;
    public Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        HealthBar.maxValue = health;

        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            DropAmmo();
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    void DropAmmo()
    {
        int randomNumber = Random.Range(0,101);
        if(randomNumber <= AmmoChance)
        {
            Instantiate(Ammo, transform.position, Quaternion.identity);
        }
    }
}
