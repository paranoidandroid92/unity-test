using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followObject;
    public float distanceX;
    public float distanceY;
    public float distanceZ;


    void Update()
    {
        float ZPosition = followObject.transform.position.z - distanceZ;
        float XPosition = followObject.transform.position.x ;
        float YPosition = followObject.transform.position.y + distanceY;
        transform.position = new Vector3(XPosition, YPosition, ZPosition);         
    }
}
