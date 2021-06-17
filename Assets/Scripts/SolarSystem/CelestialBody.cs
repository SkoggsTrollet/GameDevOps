using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField] bool isSun;

    public float radius;
    public float surfaceGravity;
    public Vector3 initialVelocity;
    public Body body;
    public float Mass => surfaceGravity * radius * radius / Universe.gravitationalConstant;

    void Awake()
    {
        body = new Body(isSun, initialVelocity, transform.position, surfaceGravity, radius);
    }

    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        Body[] bodies = new Body[allBodies.Length];

        for (int i = 0; i < allBodies.Length; i++)
        {
            bodies[i] = allBodies[i].body;
        }

        body.UpdateVelocity(bodies, timeStep);
    }

    public void UpdatePosition(float timeStep)
    {
        body.UpdatePosition(timeStep);
        transform.position = body.position;
    }
}
