using NUnit.Framework;

public class SpaceshipControllerTest
{
    [Test]
    public void min_velocity_is_10_when_set_to_10()
    {
        SpaceshipController shipController = new SpaceshipController(10);

        Assert.That(shipController.GetMinVelocity(), Is.EqualTo(10));
    }

    [Test]
    public void initial_velocity_is_10_when_min_velocity_is_set_to_10()
    {
        SpaceshipController shipController = new SpaceshipController(10);

        Assert.That(shipController.GetVelocity(), Is.EqualTo(10));
    }
}
