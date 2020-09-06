using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text txtScore;

    [SerializeField] SoundManager soundManager;

    float currentScore = 0;

    float bestScore = 0;

    private void Start()
    {
        txtScore.text = currentScore.ToString();
        if (PlayerPrefs.HasKey("bestscore20200905635"))
        {
            bestScore = PlayerPrefs.GetFloat("bestscore20200905635");
        }
    }

    internal void AddScore()
    {
        soundManager.SoundScore();
        currentScore++;
        txtScore.text = currentScore.ToString();
    }

    internal float getCurrentScore()
    {
        return currentScore;
    }

    internal float getBestScore()
    {
        return bestScore;
    }

    internal void SetEnableScore(bool value)
    {
        txtScore.gameObject.SetActive(value);
    }

    internal void SaveNewBestScore()
    {
        bestScore = currentScore;
        PlayerPrefs.SetFloat("bestscore20200905635", bestScore);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if(currentScore > bestScore && txtScore.color != Color.yellow)
        {
            txtScore.color = Color.yellow;
        }
    }

}
