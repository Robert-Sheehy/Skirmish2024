using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_ProjectileAim : MonoBehaviour
{

    GameObject targetPlane;
    Renderer myRenderer;
    float singleTargetMaxRange = 10;
    float areaTargetMaxRange = 20;
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
        targetPlane.transform.localScale = defaultScale * Vector3.one;
        myRenderer = targetPlane.GetComponent<Renderer>();
        myRenderer.material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*50);
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            print("HIT! " + info.transform.gameObject.name); //This line prints 'hit' plus whatever game object you pointed to!
            targetPlane.transform.up = info.normal;             // This sets the surface of the plane object to be facing the correct way, verticle instead of horizontal etc!!!
            targetPlane.transform.position = info.point + tinyLift * info.normal;        // Sets the position of the target plane directly where the pointer hits something, but above it a little to avoid collision
            targetPlane.transform.localScale = info.distance * defaultScale * Vector3.one;
        }
        float distanceFromArcherToPoint = Vector3.Distance(theArcher.transform.position, info.point); //gets the distance from source to destination
        if (distanceFromArcherToPoint < singleTargetMaxRange)
            myRenderer.material.color = Color.green;
        else if (distanceFromArcherToPoint < areaTargetMaxRange)
            myRenderer.material.color = Color.yellow;   //This LERP is the position between the two colors here, red and yellow as orange is not available!
        // The o.5f here states to pick the color that is half way betweent he two colors
        else
        {
            myRenderer.material.color = Color.red;
        }

        //create a script on the camera, with a birds eye view, that makes it move with key presses, zoom in and zoom out using wasd to move and q and e to rotate! Tip.. keep the camera horizontal nomatter w
        //how you move it!











    }

}
