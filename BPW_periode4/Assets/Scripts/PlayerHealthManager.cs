using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    private int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    bool isDead;

    Animator m_Animator;

    public Slider HealthBar;

    private ScoreManager theScoreManager;

    public ParticleSystem ParticleEffect;

    public GameObject FinalScorePanel;


    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        m_Animator = gameObject.GetComponent<Animator>();
        HealthBar.maxValue = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if(!isDead)
            {
                Time.timeScale = 0;
                FinalScorePanel.SetActive(true);
                isDead = true;
                StartCoroutine(Die());
            }
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
        HealthBar.value = currentHealth;
    }

    IEnumerator Die()
    {
        theScoreManager.SaveHighScore();
        theScoreManager.scoreIncreasing = false;
        m_Animator.SetBool("Death", true);
        yield return new WaitForSeconds(2.5f);
        Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
