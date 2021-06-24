using UnityEngine;

public class RotationController
{
    float pitchSpeed;
    float yawSpeed; 
    float rollSpeed;

    public RotationController(float pitchSpeed, float yawSpeed, float rollSpeed)
    {
        this.pitchSpeed = Mathf.Abs(pitchSpeed);
        this.yawSpeed = Mathf.Abs(yawSpeed);
        this.rollSpeed = Mathf.Abs(rollSpeed);
    }

    public Vector3 GetRotationSpeed()
    {
        return new Vector3(pitchSpeed, yawSpeed, rollSpeed);
    }
}
