using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_ProjetileAim : MonoBehaviour
{
    GameObject targetPlane;
    Renderer myRender;
    float singleTargetMaxRange = 10;
    private float areaTargetMaxRange =  30;
    private float defaultScale = 0.01f;
    float tinyLift = 0.01f;
    public GameObject theArcher;

    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 50f;


    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        targetPlane.GetComponent<Collider>().enabled = false; 
        targetPlane.transform.position = Vector3.zero;
        targetPlane.transform.rotation = Quaternion.identity;
        targetPlane.transform.localScale = 0.1f*Vector3.one;
        myRender = targetPlane.GetComponent<Renderer>();
        myRender.material.color = Color.red;        
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);  // Set bird's-eye view
    }

    // Update is called once per frame
    void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50);
        RaycastHit info;

        //print(Input.mouseScrollDelta.y);
        //print(Input.mouseScrollDelta.x);
        if (shouldMoveIn()) moveIn();
        if (shouldMoveOut()) moveOut();

        if (Physics.Raycast(ray, out info))
        {
            print("Hit" + info.transform.gameObject.name);
            
            targetPlane.transform.up = info.normal;
            targetPlane.transform.position = info.point + tinyLift * info.normal;

            targetPlane.transform.localScale = info.distance * defaultScale * Vector3.one;

            float distanceFromArcherToPoint = Vector3.Distance(theArcher.transform.position,  info.point);
            if (distanceFromArcherToPoint < singleTargetMaxRange)
                myRender.material.color = Color.green;
            else
                if (distanceFromArcherToPoint < areaTargetMaxRange)
                 myRender.material.color = Color.Lerp(Color.red,Color.yellow, 0.5f); //Color.yellow; this could be used to replace the orange that's not as clear
            else 
            {
                myRender.material.color = Color.red;

            }

            // Move left/right using Left Arrow and Right Arrow keys
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
            }

            // Rotate camera left/right using A and D keys
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);  // Rotate left
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);   // Rotate right
            }

            // Zoom in/out using mouse scroll
            //cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, minZoom, maxZoom);

        }

        //private bool shouldMove(){}
        //using UnityEngine;


    
    }

    private void moveOut()
    {
        transform.position -= transform.forward;
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
        //throw new NotImplementedException();
    }

    private void moveIn()
    {
        //throw new NotImplementedException();
    }

    private bool shouldMoveOut()
    {
        throw new NotImplementedException();
    }

    private bool shouldMoveIn()
    {
        throw new NotImplementedException();
    }


    //Create a script to make the camera move
    // with key press. make it move left, right and rotae left and right.
    // with a birds eye view. Zoom in and xoom out
    //Keep the camera horizontal
}

