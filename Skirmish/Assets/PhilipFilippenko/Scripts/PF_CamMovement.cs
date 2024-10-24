using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_CamMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                // Cam Move Speed
    public float shiftSpeedMultiplier = 30f;    // Cam Move Speed Multiplier
    public float rotationSpeed = 20f;           // Cam Rotation Speed
    public Transform cameraTransform;
    public Transform lookAtTarget;
    public float zoomSpeed = 10f;               // Speed for zooming
    public float minZoomDistance = 2f;          // Minimum distance from the camera to the target
    public float maxZoomDistance = 50f;         // Maximum distance from the camera to the target

    void Start()
    {
        // Assign cameraTransform if not assigned
        if (cameraTransform == null)
        {
            cameraTransform = this.transform;
        }

        // Assign lookAtTarget if not assigned
        if (lookAtTarget == null)
        {
            lookAtTarget = new GameObject("LookAtTarget").transform;
            lookAtTarget.position = cameraTransform.position + cameraTransform.forward;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        ZoomCamera();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float currentMoveSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed *= shiftSpeedMultiplier;
        }

        // Add "forward" and "right" variables
        Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;

        // Add Movement
        Vector3 movement = (forward * vertical + right * horizontal) * currentMoveSpeed * Time.deltaTime;
        cameraTransform.position += movement;
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(-rotationSpeed * Time.deltaTime);      // Rotation Left
        }

        if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(rotationSpeed * Time.deltaTime);       // Rotation Right
        }
    }

    private void ZoomCamera()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");                                 // Get mouse scrollwheel input

        Vector3 direction = cameraTransform.forward;
        Vector3 newPosition = cameraTransform.position + direction * scrollInput * zoomSpeed;

        float distanceToTarget = Vector3.Distance(newPosition, lookAtTarget.position);
        if (distanceToTarget > minZoomDistance && distanceToTarget < maxZoomDistance)           // Make the camera does
        {                                                                                       // not exceed max and min distance
            cameraTransform.position = newPosition;
        }

        else if (distanceToTarget <= minZoomDistance)
        {
            cameraTransform.position = lookAtTarget.position - direction * minZoomDistance;     // Make sure if distance to target is
                                                                                                // not exceeding min distance (not working)
        }
    }

    private void RotateCamera(float angle)
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);   // Find place where camera hits surface
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
