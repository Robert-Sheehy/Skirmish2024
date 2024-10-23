using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RL_CameraScript : MonoBehaviour
{
    RL_GameManagerScript theManager;

    enum CameraStates { Default,Ranged, Melee}
    CameraStates state = CameraStates.Default;
    float minHeight = 5f;
    float maxHeight = 50f;
    float zoomStep = 2;
    private float cameraSpeed = 20;
    bool hasFocus;
    Vector3 focusTarget;



    // Start is called before the first frame update
    void Start()
    {

        hasFocus = false ;
        focusTarget = new Vector3 (0, 0, 0);
        transform.position = new Vector3(0, 20, 20);  // starting Camera Position
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

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

        switch (state)
        {
            case CameraStates.Default:
                turnOffRangedGizmo();

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
        projectileGizmo.Disable();
    }


    private void turnOnRangedGizmo(RL_UnitMovementScript selectedUnit)
    {
       
        projectileGizmo.setProjectileSource(selectedUnit);
    }

    private void setFocus()
    {
       
        RaycastHit info;
        Ray mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(mousePoint.origin, 200 * mousePoint.direction, Color.blue, 5);

        if (Physics.Raycast(mousePoint, out info))
        {
            print("Hit Something" + info.transform.name);
            RL_UnitMovementScript possibleUnit = info.transform.GetComponent<RL_UnitMovementScript>();
            if (possibleUnit != null)
            {
                if (selectedUnit == null)
                {
                    selectedUnit = possibleUnit;
                    state = CameraStates.Ranged;
                    turnOnRangedGizmo(selectedUnit);
                    Highlight(selectedUnit);

                }
                else
                {
                    DeSelectUnit(selectedUnit);  // removes text 
                    if (possibleUnit == selectedUnit)
                    {
                        selectedUnit = null;
                        state = CameraStates.Default;
                        turnOffRangedGizmo();

                    }
                    else
                    {
                        selectedUnit = possibleUnit;
                        turnOnRangedGizmo(selectedUnit);
                        Highlight(selectedUnit);
                        state = CameraStates.Ranged;

                    }


                }
            }
           
        }

    }

    private void DeSelectUnit(RL_UnitMovementScript selectedUnit)
    {
        RL_TestInstanceScript myText = selectedUnit.GetComponentInChildren<RL_TestInstanceScript>();
        Destroy(myText.gameObject);
    }

    private void Highlight(RL_UnitMovementScript selectedUnit)
    {
        RL_TestInstanceScript myText = theManager.GetText();
        myText.initialize("Select");
       
        myText.SetColor(Color.red);
        myText.SetPosition(new Vector2(1, 1));
        myText.AttachTo(selectedUnit.transform);
      
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
       return  Input.GetKey(KeyCode.A);
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
        transform.position += cameraSpeed *dir * Time.deltaTime;
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
