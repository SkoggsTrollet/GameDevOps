using UnityEngine;

public class SpeedController
{
    float minSpeed;
    float maxSpeed;
    float speed;
    float acceleration;


    public SpeedController(float minSpeed, float maxSpeed, float acceleration)
    {
        this.minSpeed = Mathf.Abs(minSpeed);
        this.maxSpeed = Mathf.Abs(maxSpeed);
        this.acceleration = Mathf.Abs(acceleration);
        speed = this.minSpeed;
    }

    public void UpdateSpeed(float timestep, int direction)
    {
        if (timestep < 0) { return; }

        speed += direction * acceleration * timestep;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }

    public float GetMinSpeed()
    {
        return minSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }
}
