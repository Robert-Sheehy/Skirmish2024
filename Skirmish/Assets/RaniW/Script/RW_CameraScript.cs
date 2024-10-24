using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_CameraScript : MonoBehaviour
{
    enum CameraStates { Default, Ranged, Melee }
    CameraStates state = CameraStates.Default;
    float minHeight = 5f;
    float maxHeight = 50f;
    float zoomStep = 2;
    private float cameraSpeed = 20;
    bool hasFocus;
    Vector3 focusTarget;

    RW_ProjetileAim projectileGizmo;

    // Start is called before the first frame update
    void Start()
    {
        projectileGizmo = GetComponent<RW_ProjetileAim>();
        projectileGizmo.enabled = false;
        hasFocus = false;
        focusTarget = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, 20, 20);  // starting Camera Position
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CameraStates.Default:
                turnOffRangedGizmo();
                if (shouldMoveIn()) zoomIn();
                if (shouldMoveOut()) zoomOut();
                if (shouldMoveForward()) moveForward();
                if (shouldMoveBack()) moveBack();
                if (shouldMoveLeft()) moveLeft();
                if (shouldMoveRight()) moveRight();

                if (shouldTrySelect())
                {
                    setFocus();
                }
                mouseRotate();
                break;
            case CameraStates.Ranged:

                break;

            case CameraStates.Melee:


                break;
        }
    }

    private static bool shouldTrySelect()
    {
        return Input.GetMouseButtonDown(1);
    }

    private void turnOffRangedGizmo()
    {

    }

    private void setFocus()
    {

        RaycastHit info;
        if (Physics.Raycast(transform.position, transform.forward, out info))
        {
           // RW_Movement
            //focusTarget = info.point;
        }

    }

    private void moveRight()
    {
        transform.position += cameraSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldMoveRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void moveLeft()
    {
        transform.position -= cameraSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldMoveLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void mouseRotate()
    {
        if (Input.GetMouseButton(0))
        {
            Quaternion rotation = transform.rotation;

            if (hasFocus)
            {
                transform.RotateAround(focusTarget, Vector3.up, Input.GetAxis("Horizontal"));
                transform.RotateAround(focusTarget, transform.right, Input.GetAxis("Vertical"));
                transform.LookAt(focusTarget);
                ClampHeight();
            }
            else
            {
                transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"), Space.World);
                transform.Rotate(Vector3.right, Input.GetAxis("Vertical"), Space.Self);
            }
            if (hasRotatedTooFar())
                transform.rotation = rotation;
        }
    }

    private bool hasRotatedTooFar()
    {
        return !((Vector3.Dot(transform.forward, Vector3.down) >= 0) &&
           (transform.up.y >= 0));

    }

    private void moveBack()
    {
        Vector3 dir = (new Vector3(transform.forward.x, 0, transform.forward.z)).normalized;
        transform.position -= cameraSpeed * dir * Time.deltaTime;

    }

    private bool shouldMoveBack()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void moveForward()
    {
        Vector3 dir = (new Vector3(transform.forward.x, 0, transform.forward.z)).normalized;
        transform.position += cameraSpeed * dir * Time.deltaTime;
    }



    private void zoomOut()
    {
        transform.position -= zoomStep * transform.forward;
        ClampHeight();
    }



    private void zoomIn()
    {
        transform.position += zoomStep * transform.forward;
        ClampHeight();
    }

    private bool shouldMoveForward()
    {
        return Input.GetKey(KeyCode.W);
    }


    private bool shouldMoveOut()
    {
        return (Input.mouseScrollDelta.y < 0);
    }

    private bool shouldMoveIn()
    {
        return (Input.mouseScrollDelta.y > 0);
    }

    private void ClampHeight()
    {
        transform.position = new Vector3(transform.position.x,
                                        Mathf.Clamp(transform.position.y, minHeight, maxHeight),
                                        transform.position.z);
    }
}
