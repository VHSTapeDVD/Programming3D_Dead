using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraMovement_Player : MonoBehaviour
{
    public float SensitivityX;
    public float SensitivityY;
    [SerializeField] private Transform _playerBody;
    public Transform Orientation; // Assign the camera's transform to this in the editor

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

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); // Update the camera's rotation
        Orientation.rotation = Quaternion.Euler(0, rotationY, 0); // Update the player's body rotation
    }
}
