using NUnit.Framework;

public class HealthSystemTest
{
    [Test]
    public void has_5_hitpoints_if_initial_hitpoints_was_set_as_5()
    {
        HealthSystem healthSystem = new HealthSystem(5);

        Assert.AreEqual(5, healthSystem.GetHitPoints());
    }

    [TestCase(5, 5)]
    [TestCase(1, -2)]
    public void contructed_with_correct_values(int expected, int hitPoints)
    {
        HealthSystem healthSystem = new HealthSystem(hitPoints);

        Assert.AreEqual(expected, healthSystem.GetHitPoints());
    }

    [TestCase(4, 1)]
    [TestCase(0, 6)]
    [TestCase(5, -1)]
    public void damaged_with_correct_values(int expected, int damage)
    {
        HealthSystem healthSystem = new HealthSystem(5);

        healthSystem.TakeDamage(damage);

        Assert.AreEqual(expected, healthSystem.GetHitPoints());
    }

    [TestCase(3, 2, 5, 1)]
    [TestCase(5, 10, 5, 1)]
    [TestCase(1, -2, 5, 1)]
    [TestCase(0, 10, 5, 0)]
    public void replenish_with_correct_values(int expected, int replenishAmount, int maxHitPoints, int initialHitPoints)
    {
        HealthSystem healthSystem = new HealthSystem(maxHitPoints);
        healthSystem.SetHitPoints(initialHitPoints);

        healthSystem.Replenish(replenishAmount);

        Assert.AreEqual(expected, healthSystem.GetHitPoints());
    }
}
