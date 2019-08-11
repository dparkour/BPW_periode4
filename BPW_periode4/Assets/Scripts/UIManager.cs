using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    GunController gunController;
    ScoreManager scoreManager;

    public Text AmmoText;
    public Text ScoreText;        
    public Text HighscoreText;


    private void Start()
    {
        scoreManager = ScoreManager.Instance;
        gunController = GunController.Instance;
        HighscoreText.text = "Highscore: " + Mathf.Round(PlayerPrefs.GetFloat("Highscore"));
    }
    // Update is called once per frame
    void Update()
    {
        AmmoText.text = "Ammo: " + gunController.Ammo;
        ScoreText.text = "Score: " + Mathf.Round(scoreManager.scoreCount);
    }
}
