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
    // Make sure the screen size has been updated before running tests
    [TestCase(
        1920 / 2 + 1, 1080 / 2 + 1,
        1, 1,
        0, 0)]
    [TestCase(
        1920 / 2, 1080 / 2,
        1, 1,
        0, 0)]
    [TestCase(
        1920 / 4, 1080 / 2,
        0, 0,
        -1, 0)]
    [TestCase(
        1920 * 3 / 4, 1080 / 2,
        0, 0,
        1, 0)]
    [TestCase(
        1920 / 2, 1080 / 4,
        0, 0,
        0, -1)]
    [TestCase(
        1920 / 2, 1080 * 3 / 4,
        0, 0,
        0, 1)]
    [TestCase(
        1920 / 2 + 1, 1080 / 2 + 1,
        0, 0,
        0.5f, 0.5f)]
    public void calculate_inner_limit_mouse_position_properly(
        float xMousePos, float yMousePos,
        float xInnerLimit, float yInnerLimt,
        float xExpected, float yExpected)
    {
        Vector2 mousePos = new Vector2(xMousePos, yMousePos);
        Vector2 innerLimit = new Vector2(xInnerLimit, yInnerLimt);
        Vector2 expected = new Vector2(xExpected, yExpected);

        RotationController rotationController = new RotationController(0, 0, 0, innerLimit, Vector2.one * 2);

        rotationController.CalculateMouseDistance(mousePos);

        Assert.That(rotationController.GetMouseDistance(), Is.EqualTo(expected));
    }


    [TestCase(
        1920 / 2 - 5, 1080 / 2 - 5,
        5, 5,
        -1, -1)]
    [TestCase(
        1920 / 2 - 6, 1080 / 2 - 5,
        5, 5,
        -1, -1)]
    [TestCase(
        1920, 1080,
        1920 / 2, 1080 / 2,
        1, 1)]
    public void calculate_outer_limit_mouse_position_properly(
        float xMousePos, float yMousePos,
        float xOuterLimit, float yOuterLimit,
        float xExpected, float yExpected)
    {
        Vector2 mousePos = new Vector2(xMousePos, yMousePos);
        Vector2 outerLimit = new Vector2(xOuterLimit, yOuterLimit);
        Vector2 expected = new Vector2(xExpected, yExpected);

        RotationController rotationController = new RotationController(0, 0, 0, Vector2.one, outerLimit);

        rotationController.CalculateMouseDistance(mousePos);

        Assert.That(rotationController.GetMouseDistance(), Is.EqualTo(expected));
    }

    [Test]
    public void limits_set_properly()
    {
        Vector2 innerLimit = new Vector2(1, 1);
        Vector2 outerLimit = new Vector2(0, 0);

        RotationController rotationController = new RotationController(0, 0, 0, innerLimit, outerLimit);

        Assert.That(rotationController.GetOuterLimit().x, Is.GreaterThan(rotationController.GetInnerLimit().x));
        Assert.That(rotationController.GetOuterLimit().y, Is.GreaterThan(rotationController.GetInnerLimit().y));
    }
}
