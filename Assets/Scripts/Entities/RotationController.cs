using UnityEngine;

public class RotationController
{
    float pitchSpeed;
    float yawSpeed; 
    float rollSpeed;

    Vector2 innerLimit;
    Vector2 outerLimit;

    float pitchDelta;
    float yawDelta;
    float rollDelta;

    Vector2 mouseDistance;

    public RotationController(float pitchSpeed, float yawSpeed, float rollSpeed, Vector2 innerLimit, Vector2 outerLimit)
    {
        this.pitchSpeed = Mathf.Abs(pitchSpeed);
        this.yawSpeed = Mathf.Abs(yawSpeed);
        this.rollSpeed = Mathf.Abs(rollSpeed);

        this.innerLimit = innerLimit;
        this.outerLimit = outerLimit;

        ClampLimits();
    }

    private void ClampLimits()
    {
        if (outerLimit.x > Screen.width / 2)
        {
            outerLimit.x = Screen.width / 2;
        }
        if (outerLimit.y > Screen.height / 2)
        {
            outerLimit.y = Screen.height / 2;
        }

        if (innerLimit.x > Screen.width / 2)
        {
            innerLimit.x = 5;
        }
        if (innerLimit.y > Screen.height / 2)
        {
            innerLimit.y = 5;
        }

        if (outerLimit.magnitude <= innerLimit.magnitude)
        {
            outerLimit = innerLimit + Vector2.one;
        }
    }

    public void UpdateRotation(float direction, float timeStep)
    {
        pitchDelta = mouseDistance.y * timeStep * pitchSpeed;
        yawDelta = mouseDistance.x * timeStep * yawSpeed;
        rollDelta = direction * timeStep * rollSpeed;
    }

    public void UpdateMouseDistance(Vector2 mousePos, Vector2 screenSize)
    {
        mouseDistance = Vector2.zero;

        if(mousePos.x > screenSize.x / 2 + innerLimit.x)
        {
            mouseDistance.x = (mousePos.x - (screenSize.x / 2 + innerLimit.x)) / (outerLimit.x - innerLimit.x);
        }
        else if(mousePos.x < screenSize.x / 2 - innerLimit.x)
        {
            mouseDistance.x = (mousePos.x - (screenSize.x / 2 - innerLimit.x)) / (outerLimit.x - innerLimit.x);
        }

        if(mousePos.y > screenSize.y / 2 + innerLimit.y)
        {
            mouseDistance.y = (mousePos.y - (screenSize.y / 2 + innerLimit.y)) / (outerLimit.y - innerLimit.y);
        }
        else if(mousePos.y < screenSize.y / 2 - innerLimit.y)
        {
            mouseDistance.y = (mousePos.y - (screenSize.y / 2 - innerLimit.y)) / (outerLimit.y - innerLimit.y);
        }

        mouseDistance.x = Mathf.Clamp(mouseDistance.x, -1, 1);
        mouseDistance.y = Mathf.Clamp(mouseDistance.y, -1, 1);
    }

    public Vector3 GetRotationSpeed()
    {
        return new Vector3(pitchSpeed, yawSpeed, rollSpeed);
    }

    public Vector3 GetDeltaRotation()
    {
        return new Vector3(pitchDelta, yawDelta, rollDelta);
    }

    public Vector2 GetMouseDistance()
    {
        return mouseDistance;
    }

    public Vector2 GetInnerLimit()
    {
        return innerLimit;
    }

    public Vector2 GetOuterLimit()
    {
        return outerLimit;
    }
}
