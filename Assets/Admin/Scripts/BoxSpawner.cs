using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    [SerializeField] float maxTime = 1.2f;

    private float time = 0;

    [SerializeField] float height;

    [SerializeField] Transform bind;

    [SerializeField] Bird bird;

    [SerializeField] GamesManager gameManager;

    [SerializeField] ScoreManager scoreManager;



    public static BoxSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetCurrentState() == STATEGAME.PLAYING)
        {
            if (time > maxTime)
            {
                GameObject newBox = Instantiate(Resources.Load(@"Prefabs\Box") as GameObject, bind);
                newBox.transform.position = bind.position + new Vector3(0, UnityEngine.Random.Range(-height, height), 0);
                for (int i = 0; i < newBox.transform.childCount - 1; i++)
                {
                    newBox.transform.GetChild(i).GetComponent<Box>().bird = bird;
                    newBox.transform.GetChild(i).GetComponent<Box>().gameManager = gameManager;
                }
                newBox.transform.GetChild(newBox.transform.childCount - 1).GetComponent<BoxPoint>().bird = bird;
                newBox.transform.GetChild(newBox.transform.childCount - 1).GetComponent<BoxPoint>().scoreManager = scoreManager;

                Destroy(newBox, 15);
                time = 0;
            }

            time += Time.deltaTime;
        }
    }
}
