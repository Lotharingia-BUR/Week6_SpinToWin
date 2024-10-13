using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radius = 2f;
    public float speed = 2f;

    private void Update()
    {
        OrbitalMotion(radius, speed * Mathf.Deg2Rad, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        float angle = Mathf.Atan2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.position = transform.position + new Vector3(Mathf.Cos(speed), Mathf.Sin(speed), 0) * Time.deltaTime;
    }
}
