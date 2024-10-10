using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAim : MonoBehaviour
{
    GameObject targetPlane;
    Renderer myRenderer;
    private float singleTargetMaxRange = 10;
    private float areaTargetMaxRange = 20;
    private float defaultScale = 0.1f;
    float tinyLift = 0.01f;
    public GameObject TheArcher;
    // Start is called before the first frame update
    void Start()
    {
        targetPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        targetPlane.GetComponent<Collider>().enabled = false;
        targetPlane.transform.position = Vector3.zero;
        targetPlane.transform.rotation = Quaternion.identity;
        targetPlane.transform.localScale = 0.10f*Vector3.one;
        Renderer myRenderer = targetPlane.GetComponent<Renderer>();
        myRenderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera direction on mouse movement
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*50);
        RaycastHit info;
            
        if (Physics.Raycast(ray, out info))
        {
            print("Hit" + info.transform.gameObject.name);
            targetPlane.transform.position = info.point + tinyLift * info.normal;

            targetPlane.transform.localScale = info.distance * defaultScale * Vector3.one;
            targetPlane.transform.up = info.normal;

            float distanceFromArcherToPoint = Vector3.Distance(TheArcher.transform.position, info.point);

            if(distanceFromArcherToPoint < singleTargetMaxRange)
            {
                myRenderer.material.color = Color.green;
            }
            else
            {
                if (distanceFromArcherToPoint > areaTargetMaxRange)
                {
                    myRenderer.material.color = Color.Lerp(Color.red, Color.yellow, 0.5f);
                }
                else
                {
                    myRenderer.material.color = Color.red;
                }
            }
        }
        //make the camera move with key press(rotate left & right, move forward & backward)

    }
}
