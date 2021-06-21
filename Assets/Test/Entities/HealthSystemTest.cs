using NUnit.Framework;

public class HealthSystemTest
{
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

    [TestCase(3, 2, 1)]
    [TestCase(5, 10, 1)]
    [TestCase(1, -2, 1)]
    [TestCase(0, 10, 0)]
    public void replenish_with_correct_values(int expected, int replenishAmount, int initialHitPoints)
    {
        HealthSystem healthSystem = new HealthSystem(5, initialHitPoints);

        healthSystem.Replenish(replenishAmount);

        Assert.AreEqual(expected, healthSystem.GetHitPoints());
    }
}
