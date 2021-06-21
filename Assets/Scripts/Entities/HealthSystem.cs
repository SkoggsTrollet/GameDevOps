using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    int maxHitPoints;
    int hitPoints;

    public HealthSystem(int initialHitPoints)
    {
        if (initialHitPoints < 1)
        {
            maxHitPoints = hitPoints = 1;
        }
        else
        {
            maxHitPoints = hitPoints = initialHitPoints;
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        hitPoints -= damage;
        hitPoints = Mathf.Clamp(hitPoints, 0, maxHitPoints);
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}
