using NUnit.Framework;

public class SpeedControllerTest
{
    [TestCase(10, 10)]
    [TestCase(-10, 10)]
    public void min_speed_is_set_properly(float minSpeed, float expected)
    {
        SpeedController speedController = new SpeedController(minSpeed, 100, 0);

        Assert.That(speedController.GetMinSpeed(), Is.EqualTo(expected));
    }

    [TestCase(100, 100)]
    [TestCase(-100, 100)]
    public void max_speed_is_set_properly(float maxSpeed, float expected)
    {
        SpeedController speedController = new SpeedController(10, maxSpeed, 0);

        Assert.That(speedController.GetMaxSpeed(), Is.EqualTo(expected));
    }

    [TestCase(10, 10)]
    [TestCase(-10, 10)]
    public void acceleration_is_set_properly(float acceleration, float expected)
    {
        SpeedController speedController = new SpeedController(10, 100, acceleration);

        Assert.That(speedController.GetAcceleration(), Is.EqualTo(expected));
    }

    [TestCase(10, 10)]
    [TestCase(-10, 10)]
    public void initial_speed_is_set_properly(float minSpeed, float expected)
    {
        SpeedController speedController = new SpeedController(minSpeed, 100, 0);

        Assert.That(speedController.GetSpeed(), Is.EqualTo(expected));
    }

    [TestCase(20, 1, 1, 21)]
    [TestCase(20, -1, 1, 19)]
    [TestCase(100, 1, 1, 100)]
    [TestCase(10, -1, 1, 10)]
    [TestCase(20, 1, -1, 20)]
    [TestCase(20, 0, 1, 20)]
    public void speed_change_properly_over_time(float initialSpeed, int direction, float timestep, float expected)
    {
        SpeedController speedController = new SpeedController(10, 100, 1);
        speedController.SetSpeed(initialSpeed);

        speedController.UpdateSpeed(timestep, direction);

        Assert.That(speedController.GetSpeed(), Is.EqualTo(expected));
    }
}
