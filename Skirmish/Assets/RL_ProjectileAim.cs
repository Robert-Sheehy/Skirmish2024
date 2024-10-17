using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_ProjectileAim : MonoBehaviour
{
    GameObject targetPlane;
    Renderer myRenderer;
    float singleTargetMaxRange = 10;
    private float areaTargetMaxRange = 20;
    private float defaultScale =0.01f;
    float tinyLift = 0.01f;
    GameObject theSelectedGO;

    // Start is called before the first frame update
    void Start()
    {
        targetPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        targetPlane.GetComponent<Collider>().enabled = false;
        targetPlane.transform.position = Vector3.zero;
        targetPlane.transform.rotation = Quaternion.identity;
        targetPlane.transform.localScale = defaultScale*Vector3.one;
        myRenderer = targetPlane.GetComponent<Renderer>();
        myRenderer.material.color = Color.red;
        targetPlane.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     Debug.DrawRay(ray.origin, ray.direction*50);
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            print("Hit " + info.transform.gameObject.name);

            targetPlane.transform.up = info.normal;
            targetPlane.transform.position = info.point + tinyLift * info.normal;

            targetPlane.transform.localScale = info.distance * defaultScale * Vector3.one;
            
            float distanceFromArcherToPoint = Vector3.Distance(theSelectedGO.transform.position,  info.point);
            if (distanceFromArcherToPoint < singleTargetMaxRange)
                myRenderer.material.color = Color.green;
            else
               if (distanceFromArcherToPoint < areaTargetMaxRange)
                myRenderer.material.color = Color.Lerp(Color.red, Color.yellow, 0.5f);
                else
            {
                myRenderer.material.color = Color.red;
            }


        }
        
    }
}
