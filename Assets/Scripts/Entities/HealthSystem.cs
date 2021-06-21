using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    int maxHitPoints;
    int hitPoints;

    bool isDead => hitPoints <= 0;

    public HealthSystem(int maxHitPoints)
    {
        if (maxHitPoints < 1)
        {
            this.maxHitPoints = hitPoints = 1;
        }
        else
        {
            this.maxHitPoints = hitPoints = maxHitPoints;
        }
    }
    
    public HealthSystem(int maxHitPoints, int initialHitPoints)
    {
        if (maxHitPoints < 1)
        {
            this.maxHitPoints = hitPoints = 1;
        }
        else
        {
            this.maxHitPoints = maxHitPoints;
            hitPoints = initialHitPoints;
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

    public void Replenish(int replenishAmount)
    {
        if(isDead || replenishAmount < 0)
        {
            return;
        }    

        hitPoints += replenishAmount;
        hitPoints = Mathf.Clamp(hitPoints, 0, maxHitPoints);
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public void SetHitPoints(int hitPoints)
    {
        this.hitPoints = hitPoints;
    }
}
