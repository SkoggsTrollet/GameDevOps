using NUnit.Framework;
using UnityEngine;

public class BodyTest
{
    Body CreateTestBody(bool isSun)
    {
        return new Body(isSun, new Vector3(0, 0, 100), Vector3.zero, 274, 2000);
    }

    [Test]
    public void no_change_in_velocity_for_sun()
    {
        Body sun = CreateTestBody(true);
        Body[] bodies = { sun };

        sun.UpdateVelocity(bodies, Universe.physicsTimeStep);
        
        Assert.AreEqual(sun.initialVelocity, sun.currentVelocity);
    }

    [Test]
    public void no_change_in_velocity_for_sun_with_other_body()
    {
        Body sun = CreateTestBody(true);
        Body body = CreateTestBody(false);
        Body[] bodies = { sun, body };

        sun.UpdateVelocity(bodies, Universe.physicsTimeStep);

        Assert.AreEqual(sun.initialVelocity, sun.currentVelocity);
    }

    [Test]
    public void change_in_velocity_for_body_with_other_body()
    {
        Body sun = CreateTestBody(true);
        Body body = CreateTestBody(false);
        Body[] bodies = { sun, body };

        body.UpdateVelocity(bodies, Universe.physicsTimeStep);

        Assert.AreNotEqual(body.initialVelocity, body.currentVelocity);
    }
}
