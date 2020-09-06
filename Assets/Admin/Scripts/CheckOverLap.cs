using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverLap
{
    public static bool DoOverlap(Vector3[] A, Vector3[] B)
    {
        Vector3 l1 = A[1];
        Vector3 l2 = B[1];
        Vector3 r1 = A[3];
        Vector3 r2 = B[3];

        // If one rectangle is on left side of other  
        if (l1.x >= r2.x || l2.x >= r1.x)
        {
            return false;
        }

        // If one rectangle is above other  
        if (l1.y <= r2.y || l2.y <= r1.y)
        {
            return false;
        }
        return true;
    }

}
