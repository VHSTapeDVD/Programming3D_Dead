using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public float SensitivityX;
    public float SensitivityY;

    public Transform LookDirection;

    float rotationX;
    float rotationY;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * SensitivityY * Time.deltaTime;

        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        LookDirection.localRotation = Quaternion.Euler(0, rotationY, 0);


    }
}
