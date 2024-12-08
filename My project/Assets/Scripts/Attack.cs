using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackRange = 10f;
    public LayerMask enemyLayers;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PerformAttack();
        }
    }
    
    void PerformAttack()
    {
        // Trigger the SwingAttack animation
        animator.SetTrigger("SwingAttack");

        // Draw the ray in the Scene view for debugging purposes
        Debug.DrawRay(transform.position, transform.forward * attackRange, Color.red, 2f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.forward, out hit, attackRange, enemyLayers))
        {
            Debug.Log("Hit: " + hit.transform.name); // Log the name of the hit object
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
        else
        {
            Debug.Log("No hit detected");
        }
    }    
    
}
