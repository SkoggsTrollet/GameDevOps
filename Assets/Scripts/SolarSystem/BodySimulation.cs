using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;

    void Awake()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        Time.fixedDeltaTime = Universe.physicsTimeStep;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Universe.physicsTimeStep);
        }
    }
}
