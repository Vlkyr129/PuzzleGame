using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 100f;
    float xRotation = 0f;

    public Transform playerBodyRotationControl;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBodyRotationControl.Rotate(Vector3.up * mouseX);
    }
}
