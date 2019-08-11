using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public GameObject HighscoreText;
    public Text FinalScoreText;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }
    }

    public void SaveHighScore()
    {
        FinalScoreText.text = "" + Mathf.Round(scoreCount);
        if (PlayerPrefs.GetFloat("Highscore") < scoreCount || PlayerPrefs.GetFloat("Highscore") == 0)
        {
            HighscoreText.SetActive(true);
            PlayerPrefs.SetFloat("Highscore", scoreCount);
        }
    }
}
