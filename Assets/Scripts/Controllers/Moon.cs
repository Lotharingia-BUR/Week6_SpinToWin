using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radius = 2f;
    public float speed = 10f;
    public float angle = 0f;

    private void Update()
    {
        OrbitalMotion(radius, speed * Mathf.Deg2Rad, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angle += speed;

        if (angle> 360)
        {
            angle -= 360;
        }
        transform.position = target.position - circleMove(angle) * radius;
    }
    public Vector3 circleMove(float rotatePoint)
    {
        return new Vector3(Mathf.Cos(rotatePoint * Mathf.Deg2Rad), Mathf.Sin(rotatePoint * Mathf.Deg2Rad), 0);
    }
}

