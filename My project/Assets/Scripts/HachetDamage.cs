using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachetDamage : MonoBehaviour
{

    private Rigidbody rb;

    private bool hasHit = false;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            return;
        if (hasHit)
            return;
        else
            hasHit = true;

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    
        Enemy enemy = collision.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

    }
}
