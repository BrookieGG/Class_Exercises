using UnityEngine;

public class Turret : MonoBehaviour
{


    public float angularSpeed = 22f;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionTarget = (target.position - transform.position).normalized;

        float upAngle = CalculateDegAngleFromVector(transform.up);
        float directionAngle = CalculateDegAngleFromVector(directionTarget);

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);
        float sign = Mathf.Sign(deltaAngle);

        float angleStep = angularSpeed * Time.deltaTime * sign;

        if (Mathf.Abs(angleStep) < Mathf.Abs(deltaAngle))
            transform.Rotate(0, 0, angleStep);
        else
            transform.Rotate(0, 0, deltaAngle);

        float dot = Vector3.Dot(transform.up, directionTarget);

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);
        Debug.DrawLine(transform.position, transform.position + (Vector3)directionTarget, Color.magenta);

        if (dot < 0) Debug.Log($"<color=red><size=16>Behind!</size></color>");
        if (dot > 0) Debug.Log($"<color=red><size=16>In Front!</size></color>");

    }
    private float CalculateDegAngleFromVector(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;



    }

}
