using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rs_moveCamera : MonoBehaviour
{
    float speed = 30f;
    float turningSpeed = 75f;
    float minHeight = 5f;
    float maxHeight = 50f;
    float zoomStep = 2;
    private float cameraSpeed = 3;

    void Start()
    {
        transform.position = new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldZoomIn()) zoomIn();
        if (shouldZoomOut()) zoomOut();
        

        mouseRotate();

        if (shouldMoveForward()) moveForward();
        if (shouldMoveBack()) moveBack();
        if (shouldMoveLeft()) moveLeft();
        if (shouldMoveRight()) moveRight();

    }

    private void moveRight()
    {
        transform.position += cameraSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldMoveRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    private void moveLeft()
    {
        transform.position -= cameraSpeed * transform.right * Time.deltaTime;
    }

    private bool shouldMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    private void mouseRotate()
    {
        
        if (Input.GetMouseButton(0))
        {
            Quaternion rotation = transform.rotation;
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"), Space.World);
            transform.Rotate(Vector3.right, Input.GetAxis("Vertical"), Space.Self);
            if (hasRotatedTooFar())
                transform.rotation = rotation; 
        }
    }

    private bool hasRotatedTooFar()
    {
        return !((Vector3.Dot(transform.forward, Vector3.down) >= 0) &&
        (transform.up.y > 0));

    }

    private void zoomIn()
    {
        transform.position += zoomStep * transform.forward;
        ClampHeight();
    }

    private void zoomOut()
    {
        transform.position -= zoomStep * transform.forward;
        ClampHeight();
    }

    private bool shouldZoomIn()
    {

        return (Input.mouseScrollDelta.y > 0);
    }

    private bool shouldZoomOut()
    {

        return (Input.mouseScrollDelta.y < 0);
    }
    private void moveForward()
    {
        Vector3 dir = (new Vector3(transform.forward.x, 0, transform.forward.z)).normalized;
        transform.position += cameraSpeed * dir * Time.deltaTime;

    }

    private void moveBack()
    {
        Vector3 dir = (new Vector3(transform.forward.x, 0, transform.forward.z)).normalized;
        transform.position -= cameraSpeed * dir * Time.deltaTime;

    }

    private bool shouldMoveForward()
    {

        return Input.GetKey(KeyCode.UpArrow);
    }

    private bool shouldMoveBack()
    {

        return Input.GetKey(KeyCode.DownArrow);
    }
    

    private void ClampHeight()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }
}
