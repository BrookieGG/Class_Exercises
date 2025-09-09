using UnityEngine;
using System.Collections.Generic;

public class NormalizedMethod : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(NormalizedVector(new Vector2(3, 4)));
        Debug.Log(NormalizedVector(new Vector2(-3, 2)));
        Debug.Log(NormalizedVector(new Vector2(1.5f, -3.5f)));
    }
    private Vector2 NormalizedVector(Vector2 v)
    {
        float magnitude = v.magnitude;

        Vector2 normalized = new Vector2(v.x / magnitude, v.y / magnitude);
        return normalized;
    }
}
