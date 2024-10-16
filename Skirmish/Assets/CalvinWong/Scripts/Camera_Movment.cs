//Camera Movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float minHeight = 10f;
    public float maxHeight = 50f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,20,0);
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMoveForwward()) moveForward();
        if(shouldMoveBackward()) moveBackward();
        if(shouldTurnLeft()) moveLeft();
        if(shouldTurnRight()) moveRight();
        if (shouldZoomOut()) zoomOut();
        if(shouldZoomIn()) zoomIn();

        mouseRotate();

    }

    private bool shouldMoveForwward()
    {
        return Input.GetKey(KeyCode.W);
    }
    private bool shouldMoveBackward()
    {
        return Input.GetKey(KeyCode.S);
    }
    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }
    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }


    void moveLeft()
    {
        transform.position -= movementSpeed * transform.right * Time.deltaTime;
    }
    void moveRight()
    {
        transform.position += movementSpeed * transform.right * Time.deltaTime;
    }
    void moveForward()
    {
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.x).normalized;
        transform.position += movementSpeed * dir * Time.deltaTime;
    }
    void moveBackward()
    {
        Vector3 dir = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        transform.position -= movementSpeed * dir * Time.deltaTime;
    }

    
    private void mouseRotate()
    {
        if(Input.GetMouseButton(0))
        {
            Quaternion rotation = transform.rotation;
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"), Space.World);
            transform.Rotate(Vector3.right, Input.GetAxis("Vertical"), Space.Self);
            if(hasRotatedTooFar())
            {
                transform.rotation = rotation;
            }
        }
    }

    private bool hasRotatedTooFar()
    {
        return !((Vector3.Dot(transform.forward, Vector3.down) >= 0) && (transform.up.y >= 0));
    }    


    private bool shouldZoomOut()
    {
        return (Input.mouseScrollDelta.y < 0);
    }
    void zoomOut()
    {

        transform.position += transform.forward;
            //transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
        transform.position = new Vector3(transform.position.y, Mathf.Clamp(transform.position.y, minHeight,maxHeight), transform.position.z);
    }
    private bool shouldZoomIn()
    {
        return (Input.mouseScrollDelta.y > 0);
    }
    void zoomIn()
    {
        transform.position -= transform.forward;
        //transform.position += transform.TransformDirection(Vector3.down) * Time.deltaTime * movementSpeed;
        transform.position = new Vector3(transform.position.y, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }
}