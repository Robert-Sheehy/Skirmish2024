using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_CamMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                    // Cam Move Speed
    public float shiftSpeedMultiplier = 30f;        // Cam Move Speed Multiplier
    public float rotationSpeed = 20f;               // Cam Rotation Speed
    public Transform cameraTransform;
    public Transform lookAtTarget;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = this.transform;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");  // A and D
        float vertical = Input.GetAxis("Vertical");      // W and S

        float currentMoveSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed *= shiftSpeedMultiplier;
        }

        Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;

        Vector3 movement = (forward * vertical + right * horizontal) * currentMoveSpeed * Time.deltaTime;
        cameraTransform.position += movement;

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(-rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(rotationSpeed * Time.deltaTime);
        }
    }

    private void RotateCamera(float angle)
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cameraTransform.RotateAround(hit.point, Vector3.up, angle);
            cameraTransform.LookAt(hit.point);
        }
        else
        {
            Vector3 defaultLookAtPoint = cameraTransform.position + cameraTransform.forward * 10f;
            cameraTransform.RotateAround(lookAtTarget.position, Vector3.up, angle);
            cameraTransform.LookAt(defaultLookAtPoint);
        }
    }
}
