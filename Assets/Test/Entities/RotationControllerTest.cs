using NUnit.Framework;

public class RotationControllerTest
{
    [TestCase(10, 10, 10, 10)]
    [TestCase(-10, -10, -10, 10)]
    public void rotation_speed_set_properly(float pitch, float yaw, float roll, float expected)
    {
        RotationController rotationController = new RotationController(pitch, yaw, roll);

        Assert.That(rotationController.GetRotationSpeed().x, Is.EqualTo(expected));
        Assert.That(rotationController.GetRotationSpeed().y, Is.EqualTo(expected));
        Assert.That(rotationController.GetRotationSpeed().z, Is.EqualTo(expected));
    }
}
