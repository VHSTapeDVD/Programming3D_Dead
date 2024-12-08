using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Enemy carriedEnemy;

    public bool IsCarryingEnemy()
    {
        return carriedEnemy != null;
    }

    public Enemy GetCarriedEnemy()
    {
        return carriedEnemy;
    }

    public void PickUpEnemy(Enemy enemy)
    {
        carriedEnemy = enemy;
        enemy.transform.position = transform.position + transform.forward * 2;
        enemy.transform.SetParent(transform);
    }

    public void DropCarriedEnemy()
    {
        if (carriedEnemy != null)
        {
            carriedEnemy.transform.SetParent(null);
            carriedEnemy = null;
        }
    }
}
