using NUnit.Framework;
using UnityEngine;

public class RotationControllerTest
{
    [TestCase(10, 10, 10, 10)]
    [TestCase(-10, -10, -10, 10)]
    public void rotation_speed_set_properly(float pitch, float yaw, float roll, float expected)
    {
        RotationController rotationController = new RotationController(pitch, yaw, roll, Vector2.zero, Vector2.zero);

        Assert.That(rotationController.GetRotationSpeed().x, Is.EqualTo(expected));
        Assert.That(rotationController.GetRotationSpeed().y, Is.EqualTo(expected));
        Assert.That(rotationController.GetRotationSpeed().z, Is.EqualTo(expected));
    }

    [TestCase(1, 1, 10, 10)]
    [TestCase(-1, 1, 10, -10)]
    public void roll_delta_calculated_properly(float direction, float timeStep, float roll, float expected)
    {
        RotationController rotationController = new RotationController(0, 0, roll, Vector2.zero, Vector2.zero);

        rotationController.UpdateRotation(direction, timeStep);

        Assert.That(rotationController.GetDeltaRotation().z, Is.EqualTo(expected));
    }


    // Using aspect ration Full HD (1920x1080) in unity
    [TestCase(
        1920/2+1,1080/2+1,
        1,1,
        0,0)]
    [TestCase(
        1920/2, 1080/2,
        1,1,
        0,0)]
    [TestCase(
        1920/4, 1080/2,
        0,0,
        -0.5f,0)]
    [TestCase(
        1920*3/4, 1080/2,
        0,0,
        0.5f,0)]
    [TestCase(
        1920/2, 1080/4,
        0,0,
        0,-0.5f)]
    [TestCase(
        1920/2, 1080*3/4,
        0,0,
        0,0.5f)]
    public void calculate_inner_limit_mouse_position_properly(
        float xMousePos, float yMousePos,
        float xInnerLimit, float yInnerLimt,
        float xExpected, float yExpected)
    {
        Vector2 mousePos = new Vector2(xMousePos, yMousePos);
        Vector2 innerLimit = new Vector2(xInnerLimit, yInnerLimt);
        Vector2 expected = new Vector2(xExpected, yExpected);

        RotationController rotationController = new RotationController(0, 0, 0, innerLimit, Vector2.zero);

        rotationController.CalculateMouseDistance(mousePos);

        Assert.That(rotationController.GetMouseDistance(), Is.EqualTo(expected));
    }
}
