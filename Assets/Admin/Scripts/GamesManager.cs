using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    [SerializeField] Bird bird;

    [SerializeField] Ground ground;

    [SerializeField] GameObject gameOver;

    [SerializeField] GameObject getReady;

    [SerializeField] Transform bind;

    [SerializeField] Animator birdGetReady;

    [SerializeField] ScoreManager scoreManager;

    [SerializeField] GameOverManager gameOverManager;

    [SerializeField] SoundManager  soundManager;

    STATEGAME currentState;

    public static GamesManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentState = STATEGAME.GETREADY;
        Time.timeScale = 1;
        gameOver.SetActive(false);
        getReady.SetActive(true);
    }

    private void Update()
    {
        if (currentState == STATEGAME.PLAYING)
        {
            CheckGameOver();
        }
    }

    internal STATEGAME GetCurrentState()
    {
        return currentState;
    }

    void CheckGameOver()
    {
        scoreManager.SetEnableScore(true);
        if (CheckOverLap.DoOverlap(bird.GetCorners(), ground.GetCorners()) == true)
        {
            DoGameOver();
            bird.transform.position = new Vector3(bird.transform.position.x, ground.GetCorners()[1].y + (bird.GetCorners()[1].y - bird.GetCorners()[0].y) / 2, bird.transform.position.z);
            return;
        }
    }


    internal void DoGameOver()
    {
        soundManager.SoundHit();
        gameOver.SetActive(true);
        Time.timeScale = 0;
        PlaySoundFall();
        if (scoreManager.getCurrentScore() > scoreManager.getBestScore())
        {
            scoreManager.SaveNewBestScore();
        }
        gameOverManager.SetResult(scoreManager.getCurrentScore(), scoreManager.getBestScore());
        scoreManager.SetEnableScore(false);
        currentState = STATEGAME.GAMEOVER;
    }

    IEnumerator PlaySoundFall()
    {
        yield return new WaitForSeconds(0.2f);
        soundManager.SoundFall();
    }

        public void RePlay()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        birdGetReady.Play("getReadyBird");
        StartCoroutine(ChangeStatuToPlaying());
    }
    IEnumerator ChangeStatuToPlaying()
    {
        yield return new WaitForSeconds(1);
        currentState = STATEGAME.PLAYING;
        bird.gameObject.SetActive(true);
        getReady.SetActive(false);
    }

}
