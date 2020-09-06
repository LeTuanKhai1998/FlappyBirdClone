using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    RectTransform rt;

    public static Ground instance;

    Vector3[] corners;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        corners = Utils.GetWorldCorners(rt);
    }

    public Vector3[] GetCorners()
    {
        return corners;
    }
}
