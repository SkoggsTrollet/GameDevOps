using NUnit.Framework;
using UnityEngine;

public class CelestialBodyTest
{
    [Test]
    public void NewTestScriptSimplePasses()
    {
        Assert.IsTrue(true);
    }

    //[Test]
    //public void  no_change_in_velocity_for_sun()
    //{
    //    CelestialBody sun = new CelestialBody();
    //    sun.isSun = true;
    //    Vector3 oldVelocity = sun.currentVelocity;
        

    //    sun.UpdateVelocity(new CelestialBody[0], Universe.physicsTimeStep);

    //    Assert.AreEqual(oldVelocity, sun.currentVelocity);
    //}
}
