using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthSystemTest
{
    [Test]
    public void has_5_hitpoints_if_initial_hitpoints_was_set_as_5()
    {
        HealthSystem healthSystem = new HealthSystem(5);

        Assert.AreEqual(5, healthSystem.GetHitPoints());
    }
}
