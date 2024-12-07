using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachetThrow : MonoBehaviour
{
    public Transform Camera;
    public GameObject Hachet;
    public Transform ThrowPoint;

    public int NumberOfHachets;
    public float Throwcooldown;

    public KeyCode ThrowKey = KeyCode.Mouse0;
    public float ThrowForce;
    public float ThrowForceUp;

    bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        CanThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(ThrowKey) && CanThrow && NumberOfHachets > 0)
        {
            ThrowHachet();
        } 
    }

    void ThrowHachet()
    {
        CanThrow = false;
        GameObject Proctectile = Instantiate(Hachet, ThrowPoint.position, Quaternion.LookRotation(Camera.transform.forward));

        Rigidbody ProctectileRB = Proctectile.GetComponent<Rigidbody>();


        Vector3 forceDirection = Camera.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(Camera.position, Camera.forward, out hit, 500f))
        {
            forceDirection = (hit.point - ThrowPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * ThrowForce + Camera.transform.up * ThrowForceUp;

        ProctectileRB.AddForce(forceToAdd, ForceMode.Impulse);

        NumberOfHachets--;

        Invoke("ResetThrow", Throwcooldown);
    }

    private void ResetThrow()
    {
        CanThrow = true;
    }


}
