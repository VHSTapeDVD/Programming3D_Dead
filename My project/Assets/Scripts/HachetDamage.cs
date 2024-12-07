using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachetDamage : MonoBehaviour
{

    private Rigidbody rb;

    private bool hasHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit)
            return;
        else
            hasHit = true;

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    
        
    }
}
