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

    [TestCase(1080 / 2, 1, 10, 0)]
    [TestCase(1080 / 2 - 2, 1, 10, -10)]
    [TestCase(1080 / 2 + 2, 1 , 10, 10)]
    [TestCase(1080 / 2 + 0.5f, 1, 10, 5)]
    public void pitch_delta_calculated_properly(float yMousePos, float timeStep, float pitch, float expected)
    {
        RotationController rotationController = new RotationController(pitch, 0, 0, Vector2.zero, Vector2.one);

        rotationController.UpdateMouseDistance(new Vector2(1920 / 2, yMousePos), new Vector2(1920, 1080));
        rotationController.UpdateRotation(0, timeStep);

        Assert.That(rotationController.GetDeltaRotation().x, Is.EqualTo(expected));
    }

    [TestCase(1920 / 2, 1, 10, 0)]
    [TestCase(1920 / 2 - 2, 1, 10, -10)]
    [TestCase(1920 / 2 + 2, 1, 10, 10)]
    [TestCase(1920 / 2 + 0.5f, 1, 10, 5)]
    public void yaw_delta_calculated_properly(float xMousePos, float timeStep, float yaw, float expected)
    {
        RotationController rotationController = new RotationController(0, yaw, 0, Vector2.zero, Vector2.one);

        rotationController.UpdateMouseDistance(new Vector2(xMousePos, 1080 / 2), new Vector2(1920, 1080));
        rotationController.UpdateRotation(0, timeStep);

        Assert.That(rotationController.GetDeltaRotation().y, Is.EqualTo(expected));
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

        rotationController.UpdateMouseDistance(mousePos, new Vector2(1920, 1080));

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

        rotationController.UpdateMouseDistance(mousePos, new Vector2(1920, 1080));

        Assert.That(rotationController.GetMouseDistance(), Is.EqualTo(expected));
    }

    [Test]
    public void outer_limit_is_greater_than_inner_limit()
    {
        Vector2 innerLimit = new Vector2(1, 1);
        Vector2 outerLimit = new Vector2(0, 0);

        RotationController rotationController = new RotationController(0, 0, 0, innerLimit, outerLimit);

        Assert.That(rotationController.GetOuterLimit().x, Is.GreaterThan(rotationController.GetInnerLimit().x));
        Assert.That(rotationController.GetOuterLimit().y, Is.GreaterThan(rotationController.GetInnerLimit().y));
    }

    [Test]
    public void outer_limit_is_lesser_than_screen_size()
    {
        Vector2 outerLimit = new Vector2(3000, 3000);

        RotationController rotationController = new RotationController(0, 0, 0, Vector2.zero, outerLimit);

        Assert.That(rotationController.GetOuterLimit().x, Is.LessThanOrEqualTo(Screen.width / 2));
        Assert.That(rotationController.GetOuterLimit().y, Is.LessThanOrEqualTo(Screen.height / 2));
    }

    [Test]
    public void inner_limit_is_lesser_than_screen_size()
    {
        Vector2 innerLimit = new Vector2(3000, 3000);

        RotationController rotationController = new RotationController(0, 0, 0, innerLimit, Vector2.zero);

        Assert.That(rotationController.GetInnerLimit().x, Is.LessThanOrEqualTo(5));
        Assert.That(rotationController.GetInnerLimit().y, Is.LessThanOrEqualTo(5));
    }
}
