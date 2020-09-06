using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float fallSpeed = 300.0f;

    [SerializeField] float flySpeed = 200.0f;

    RectTransform rt;

    [SerializeField] GamesManager gameManager;

    [SerializeField] SoundManager soundManager;

    public static Bird instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        fallSpeed *= (float)Screen.width / 480;
        flySpeed *= (float)Screen.width / 480;
    }

    internal Vector3[] GetCorners()
    {
        return Utils.GetWorldCorners(rt);
    }

    void Update()
    {
        if (gameManager.GetCurrentState() == STATEGAME.PLAYING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                soundManager.SoundFlap();
                transform.Translate(Vector3.up * flySpeed * 0.5f, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
