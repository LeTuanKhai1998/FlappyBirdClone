using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPoint : MonoBehaviour
{
    RectTransform rt;

    public Bird bird;

    public ScoreManager scoreManager;

    public static BoxPoint instance;

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
        if (CheckOverLap.DoOverlap(bird.GetCorners(), Utils.GetWorldCorners(rt)) == true)
        {
            scoreManager.AddScore();
            gameObject.SetActive(false);
        }
    }
}
