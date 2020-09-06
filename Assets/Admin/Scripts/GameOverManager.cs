using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Sprite[] spritesMetal;

    [SerializeField] Image imgMetal;

    [SerializeField] Image imgNewScore;

    [SerializeField] Text txtCurrentScore;

    [SerializeField] Text txtBestScore;


    public static GameOverManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        imgNewScore.gameObject.SetActive(false);
    }

    internal void SetResult(float currentScore, float bestScore)
    {


        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            imgNewScore.gameObject.SetActive(true);
            imgMetal.sprite = spritesMetal[spritesMetal.Length - 1];
        }
        else
        {
            if (currentScore < 10)
            {
                imgMetal.sprite = spritesMetal[0];
            }
            else
            {
                imgMetal.sprite = spritesMetal[1];
            }
        }
        txtCurrentScore.text = currentScore.ToString();

        txtBestScore.text = bestScore.ToString();
    }
}
