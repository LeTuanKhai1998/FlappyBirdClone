using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleFacter : MonoBehaviour
{
    private void Awake()
    {
        float currWidth = Screen.width;

        float currHeight = Screen.height;

        const float match = 1.9f;

        float fac = (currWidth / 1080) * (1 - match) + (currHeight / 1080) * match;

        GetComponent<CanvasScaler>().scaleFactor = fac;
    }
}
