using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    RectTransform rt;

    public Bird bird;

    public GamesManager gameManager;

    public static Box instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (gameManager.GetCurrentState() == STATEGAME.PLAYING)
        {
            if (CheckOverLap.DoOverlap(bird.GetCorners(), Utils.GetWorldCorners(rt)) == true)
            {
                gameManager.DoGameOver();
            }
        }
    }

}
