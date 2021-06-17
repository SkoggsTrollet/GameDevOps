using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body
{
    public Vector3 initialVelocity;
    public Vector3 currentVelocity;
    public Vector3 position;
    float mass;
    float radius;
    bool isSun;

    public Body(bool isSun, Vector3 initialVelocity, Vector3 position, float surfaceGravity, float radius)
    {
        this.isSun = isSun;
        this.initialVelocity = initialVelocity;
        this.currentVelocity = initialVelocity;
        this.position = position;
        this.radius = radius;
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
    }

    public void UpdateVelocity(Body[] bodies, float timeStep)
    {
        if (isSun)
        {
            return;
        }

        foreach (var body in bodies)
        {
            if (body != this)
            {
                float sqrDist = (body.position - position).sqrMagnitude;
                Vector3 forceDir = (body.position - position).normalized;
                Vector3 force = forceDir * Universe.gravitationalConstant * mass * body.mass / sqrDist;
                Vector3 acceleration = force / mass;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        position += currentVelocity * timeStep;
    }
}
