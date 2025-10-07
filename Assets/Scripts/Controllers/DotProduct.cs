using UnityEngine;

public class DotProduct : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float blueAngle = 30f;
    public float redAngle = 30f;

    private Vector2 redVector = Vector2.zero;
    private Vector2 blueVector = Vector2.zero;

    private void Update()
    {
        redVector = CalculateVectorFromAngle(redAngle);
        blueVector = CalculateVectorFromAngle(blueAngle);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.cyan);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dot = CalculateDotProduct(redVector, blueVector);
            Debug.Log($"<color=orange><size=16>{dot}</size></color>");
        }
    }

    private Vector2 CalculateVectorFromAngle(float angle)
    {
        float angleInRads = Mathf.Deg2Rad * angle;
        return new Vector2(Mathf.Cos(angleInRads), Mathf.Sin(angleInRads));
    }

    private float CalculateDotProduct(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

}
