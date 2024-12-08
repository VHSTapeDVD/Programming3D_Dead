using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehavior player = other.GetComponent<PlayerBehavior>();
        if (player != null && player.IsCarryingEnemy())
        {
            AttachEnemy(player.GetCarriedEnemy());
            player.DropCarriedEnemy();
        }
    }

    private void AttachEnemy(Enemy enemy)
    {
        // Set the enemy's position and parent to the hook's transform
        enemy.transform.position = transform.position;
        enemy.transform.SetParent(transform);

        // Disable the enemy's collider and ensure it is visible
        enemy.GetComponent<Collider>().enabled = false;
        enemy.GetComponent<Renderer>().enabled = true;
    }
}
