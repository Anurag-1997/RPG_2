using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter thirdPersonCharacter;
    CameraRaycast cameraRay;
    Vector3 currentClickTarget;
    private Vector3 currentDestination;
    public float moveStopRadius = 0.2f;
    public float attackMoveStopRadius=2f;
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>(); 
        //cameraRay= GetComponent<CameraRaycast>();
        cameraRay = Camera.main.GetComponent<CameraRaycast>();
        currentClickTarget = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            print(cameraRay.m_hit.collider.gameObject.name);
            print(cameraRay.m_layerHit);
            currentClickTarget = cameraRay.m_hit.point;
            switch (cameraRay.m_layerHit)
            {
                case Layer.WalkableArea:
                   
                    //currentDestination = currentClickTarget;
                    currentDestination = shortDestination(cameraRay.m_hit.point, moveStopRadius);

                    break;
                case Layer.Enemy:
                    currentDestination = shortDestination(cameraRay.m_hit.point, attackMoveStopRadius);
                    print("enemy area");
                    break;
                case Layer.raycastEndStop:
                    break;
                default:
                    print("no layer state");
                    break;
            }

        }
        WalkToDestination();

    }

    private void WalkToDestination()
    {
        var tempClickPoint = currentClickTarget - transform.position;
        if (tempClickPoint.magnitude >= moveStopRadius)
        {
            thirdPersonCharacter.Move(tempClickPoint, false, false);
        }
        else
        {
            thirdPersonCharacter.Move(Vector3.zero, false, false);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, currentClickTarget);
        Gizmos.DrawSphere(currentClickTarget, 0.2f);
        Gizmos.DrawSphere(currentDestination, 0.1f);
        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(transform.position, 1f);
    }

    Vector3 shortDestination(Vector3 targetDestination,float rad)
    {
        Vector3 reductionInDistance = (currentDestination - transform.position).normalized * rad;
        return targetDestination - reductionInDistance;
    }
}
