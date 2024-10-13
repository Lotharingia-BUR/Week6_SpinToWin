using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;

    public float radius = 2f;
    public float radiusPowerup = 3f;
    public int circlePoints = 9;
    public int numberOfPowerups = 3;
    public Color detected = Color.green;

    void Update()
    {

        EnemyRadar(radius, circlePoints);

        if( Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(radiusPowerup, numberOfPowerups);
        }     
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float powerupByPoints = 360 / numberOfPowerups;
        for (int i = 0; i < numberOfPowerups; i++)
        {
            Instantiate(powerupPrefab, transform.position - circleDraw(i, powerupByPoints) * radius, Quaternion.identity);
        }
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        if ((enemyTransform.position - transform.position).magnitude < radius)
        {
            detected = Color.red;
        } else
        {
            detected = Color.green;
        }
        float rotationByPoints = 360/circlePoints;
        for(int i = 1; i < circlePoints; i++)
        {
             
            Debug.Log(i);
            Debug.DrawLine(transform.position - circleDraw(i, rotationByPoints) * radius, transform.position - circleDraw(i-1, rotationByPoints) * radius , detected);
        }
        Debug.DrawLine(transform.position - circleDraw(0, rotationByPoints) * radius, transform.position - circleDraw(circlePoints - 1, rotationByPoints) * radius, detected);
    }

    public Vector3 circleDraw(int i, float rotatePoint)
    {
        return new Vector3(Mathf.Cos( rotatePoint * i * Mathf.Deg2Rad), Mathf.Sin(rotatePoint * i * Mathf.Deg2Rad), 0);
    }

}
