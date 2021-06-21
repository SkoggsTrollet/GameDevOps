using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    int hitPoints;

    public HealthSystem(int initialHitPoints)
    {
        hitPoints = initialHitPoints;
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}
