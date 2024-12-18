using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalmanFilter : MonoBehaviour
{
    private const float DEFAULT_Q = 0.000001f;
    private const float DEFAULT_R = 0.01f;
    private const float DEFAULT_P = 1f;

    private float q;
    private float r;
    private float p = DEFAULT_P;
    private Vector3 x;
    private float k;

    public KalmanFilter(float aQ = DEFAULT_Q, float aR = DEFAULT_R)
    {
        q = aQ;
        r = aR;
    }

    public Vector3 Filtering(Vector3 measurement, float? newQ = null, float? newR = null)
    {
        if (newQ != null && q != newQ) q = (float)newQ;
        if (newR != null && r != newR) r = (float)newR;

        k = (p + q) / (p + q + r);
        p = r * (p + q) / (r + p + q);

        Vector3 result = x + (measurement - x) * k;
        x = result;
        return result;
    }
}
