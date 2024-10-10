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

    // Start is called before the first frame update
    void Start()
    {
        targetPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        targetPlane.GetComponent<Collider>().enabled = false; 
        targetPlane.transform.position = Vector3.zero;
        targetPlane.transform.rotation = Quaternion.identity;
        targetPlane.transform.localScale = 0.1f*Vector3.one;
        myRender = targetPlane.GetComponent<Renderer>();
        myRender.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50);
        RaycastHit info;
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

        }

        //Create a script to make the camera move
        // with key press. make it move left, right and rotae left and right.
        // with a birds eye view. Zoom in and xoom out
        //Keep the camera horizontal
    }
}
