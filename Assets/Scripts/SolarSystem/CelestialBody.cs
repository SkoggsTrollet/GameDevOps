using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField]
    public bool isSun;
    [HideInInspector]
    public float mass;
    public float radius;
    public float SurfaceGravity;

    public Vector3 initialVelocity;
    [HideInInspector]
    public Vector3 currentVelocity;

    public float Mass => SurfaceGravity * radius * radius / Universe.gravitationalConstant;

    void Awake()
    {
        mass = SurfaceGravity * radius * radius / Universe.gravitationalConstant;
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        if (isSun)
            return;

        foreach (var otherBody in allBodies)
        {
            if(otherBody != this)
            {
                float sqrDist = (otherBody.transform.position - transform.position).sqrMagnitude;
                Vector3 forceDir = (otherBody.transform.position - transform.position).normalized;
                Vector3 force = forceDir * Universe.gravitationalConstant * mass * otherBody.mass / sqrDist;
                Vector3 acceleration = force / mass;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        transform.position += currentVelocity * timeStep;
    }
}
