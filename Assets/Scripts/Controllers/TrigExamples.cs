using UnityEngine;

public class TrigExamples : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(Vector3.zero, mousePosInWorld, Color.cyan);

        float angle = Mathf.Atan(mousePosInWorld.y / mousePosInWorld.x) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(mousePosInWorld.y / mousePosInWorld.x) * Mathf.Rad2Deg;

        

        Debug.Log($"<color=yellow><size=16>{angle}</size></color>");
    }
}
