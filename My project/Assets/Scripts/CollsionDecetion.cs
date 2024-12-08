using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDecetion : MonoBehaviour
{

    public Attack attack;
    public GameObject HitEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(HitEffect, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
        }
    }
    

    
}
