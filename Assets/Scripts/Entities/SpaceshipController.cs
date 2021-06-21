using UnityEngine;

public class SpaceshipController
{
    float minVelocity;
    float velocity;
    public SpaceshipController(float minVelocity)
    {
        this.minVelocity = minVelocity;
        velocity = minVelocity;
    }

    public float GetMinVelocity()
    {
        return minVelocity;
    }

    public float GetVelocity()
    {
        return velocity;
    }
}
