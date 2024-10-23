using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CW_Camera_Movement : MonoBehaviour
{
    enum CameraStates { Default, Ranged, Melee}
   CameraStates state = CameraStates.Default;

    float minHeight = 5f;
    float maxHeight = 50f;
    float zoomStep = 2;
    private float cameraSpeed = 20;
    bool hasFocus;
    Vector3 focusTarget;

    ProjectileAim selectedUnit;
    private ProjectileAim theManager;
    ProjectileAim projectileGizmo;
    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<ProjectileAim>();

        projectileGizmo = GetComponent<ProjectileAim>();
        projectileGizmo.enabled = false;
        hasFocus = false;
        focusTarget = new Vector3(0,10,0);

        transform.position = new Vector3(0, 20, 20);  // starting Camera Position
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case CameraStates.Default:
                if (shouldMoveIn()) zoomIn();
                if (shouldMoveOut()) zoomOut();

                if (shouldTrySelect()) 
                { 
                    
                }

                mouseRotate();

                if (Input.GetMouseButtonDown(1))
                {
                    setFocus();
                }

                if (shouldMoveForward()) moveForward();
                if (shouldMoveBack()) moveBack();
                if (shouldMoveLeft()) moveLeft();
                if (shouldMoveRight()) moveRight();
                break;

            case CameraStates.Ranged:
                turnOnRangedGizmo();

            case CameraStates.Melee:
                turnOffRangedGizmo();
        }
    }

    private void turnOffRangedGizmo()
    {
        projectileGizmo.enabled = false;
    }

    private void turnOnRangedGizmo()
    {
        projectileGizmo.enabled = true;
        //projectileGizmo.setProjectileSource();
    }

    private bool shouldTrySelect()
    {
        throw new NotImplementedException();
    }

    private void setFocus()
    {

        hasFocus = true;
        RaycastHit info;
        Ray mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(mousePoint.origin, 200 * mousePoint.direction, Color.blue, 5);

        if (Physics.Raycast(mousePoint, out info))
        {
            print("Hit Something!");
            ProjectileAim possibleUnit = info.transform.GetComponent<ProjectileAim>();
            if (possibleUnit != null)
            {
                if (selectedUnit != null)
                {
                    DeSelectedUnit(selectedUnit); //Removes text
                    if (possibleUnit == selectedUnit)
                    {
                        selectedUnit = null;
                        DeSelectedUnit(selectedUnit);
                    }
                }
                selectedUnit = possibleUnit;
                state = CameraStates.Ranged;
                turnOnRangedGizmo();
                HighLighted(selectedUnit);
            }
            else
            {
                DeSelectedUnit(selectedUnit);
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
                    HighLighted(selectedUnit);
                    state = CameraStates.Ranged;
                }
            }
            //focusTarget = info.point;
        }
    }

    private void DeSelectedUnit(ProjectileAim selectedUnit)
    {
        CW_TextInstance myText = selectedUnit.GetComponent<CW_TextInstance>();
        Destroy(myText.gameObject);
    }

    private void HighLighted(ProjectileAim selectedUnit)
    {
        CW_TextInstance myText = theManager.GetText();
        myText.Initialise("Hello");
        myText.SetText("Hello");
        myText.SetColor(Color.black);
        myText.SetPosition(new Vector2(1,1));
        myText.AttachTo(selectedUnit.transform);
        myText.StartFlash(1.0f);
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
        if(Input.GetMouseButton(0))
        {
            Quaternion rotation = transform.rotation;

            if (hasFocus)
            {
                transform.RotateAround(focusTarget, Vector3.up, Input.GetAxis("Horizontal"));
                transform.RotateAround(focusTarget, Vector3.right, Input.GetAxis("Vertical"));
            }
            else
            {
                transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"), Space.World);
                transform.Rotate(Vector3.right, Input.GetAxis("Vertical"), Space.Self);

            }
            if (hasRotatedTooFar())
            {
                transform.rotation = rotation;
            }
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

    private void turnRight()
    {
        throw new NotImplementedException();
    }

    private void turnLeft()
    {
        throw new NotImplementedException();
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

    private bool shouldTurnRight()
    {
        throw new NotImplementedException();
    }

    private bool shouldTurnLeft()
    {
        throw new NotImplementedException();
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
