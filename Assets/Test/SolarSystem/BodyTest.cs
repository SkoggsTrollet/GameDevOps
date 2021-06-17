using NUnit.Framework;
using UnityEngine;

public class BodyTest
{
    Body CreateTestBody(bool isSun, Vector3 position)
    {
        return new Body(isSun, new Vector3(0, 0, 100), position, 274, 2000);
    }

    [Test]
    public void no_change_in_velocity_for_sun()
    {
        Body sun = CreateTestBody(true, Vector3.zero);
        Body[] bodies = { sun };

        sun.UpdateVelocity(bodies, Universe.physicsTimeStep);
        
        Assert.AreEqual(sun.initialVelocity, sun.currentVelocity);
    }

    [Test]
    public void no_change_in_velocity_for_sun_with_other_body()
    {
        Body sun = CreateTestBody(true, Vector3.zero);
        Body body = CreateTestBody(false, Vector3.one);
        Body[] bodies = { sun, body };

        sun.UpdateVelocity(bodies, Universe.physicsTimeStep);

        Assert.AreEqual(sun.initialVelocity, sun.currentVelocity);
    }

    [Test]
    public void change_in_velocity_for_body_with_other_body()
    {
        Body sun = CreateTestBody(true, Vector3.zero);
        Body body = CreateTestBody(false, Vector3.one);
        Body[] bodies = { sun, body };

        body.UpdateVelocity(bodies, Universe.physicsTimeStep);

        Assert.AreNotEqual(body.initialVelocity, body.currentVelocity);
    }

    [Test]
    public void change_in_position_for_body_with_initial_velocity()
    {
        Body body = CreateTestBody(false, Vector3.one);

        Vector3 previousPosition = body.position;
        body.UpdatePosition(Universe.physicsTimeStep);

        Assert.AreNotEqual(previousPosition, body.position);
    }

    [Test]
    public void change_in_positon_for_body_without_initial_velocity_with_other_body()
    {
        Body sun = CreateTestBody(true, Vector3.zero);
        Body body = CreateTestBody(false, Vector3.one);
        Body[] bodies = { sun, body };
        body.initialVelocity = body.currentVelocity = Vector3.zero;

        body.UpdateVelocity(bodies, Universe.physicsTimeStep);
        Vector3 previousPosition = body.position;
        body.UpdatePosition(Universe.physicsTimeStep);

        Assert.AreNotEqual(previousPosition, body.position);
    }

    [Test]
    public void if_position_for_body_is_not_NaN_with_other_body()
    {
        Body sun = CreateTestBody(true, Vector3.zero);
        Body body = CreateTestBody(false, Vector3.one);
        Body[] bodies = { sun, body };
        body.initialVelocity = body.currentVelocity = Vector3.zero;
        body.position = new Vector3(10, 10, 10);

        body.UpdateVelocity(bodies, Universe.physicsTimeStep);
        body.UpdatePosition(Universe.physicsTimeStep);    

        Assert.IsFalse(float.IsNaN(body.position.x));
        Assert.IsFalse(float.IsNaN(body.position.y));
        Assert.IsFalse(float.IsNaN(body.position.z));
    }
}
