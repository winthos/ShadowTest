using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnesis : MonoBehaviour
{
    public GameObject movingObject;
    public Transform xLimUp;
    public Transform xLimDn;
    public Transform zLimUp;
    public Transform zLimDn;

    public bool xAxisOn = true;
    public bool zAxisOn = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movingObject.transform.parent == null)
            movingObject.transform.parent = this.transform;
    }

    public Vector3 MoveObject(Vector3 _newPosition)
    {
        Vector3 newPos = _newPosition;

        if (xAxisOn)
        {
            //x limits
            if (newPos.x > xLimUp.position.x)
            {
                newPos.x = xLimUp.position.x;
            }
            if (newPos.x < xLimDn.position.x)
            {
                newPos.x = xLimDn.position.x;
            }
        }
        else
        {
            newPos.x = movingObject.transform.position.x;
        }

        if (zAxisOn)
        {
            //z limits
            if (newPos.z > zLimUp.position.z)
            {
                newPos.z = zLimUp.position.z;
            }
            if (newPos.z < zLimDn.position.z)
            {
                newPos.z = zLimDn.position.z;
            }
        }
        else
        {
            newPos.z = movingObject.transform.position.z;
        }


        newPos.y = movingObject.transform.position.y;

        movingObject.transform.SetPositionAndRotation(newPos, Quaternion.identity);
        //movingObject.transform.position = newPos;
        return newPos;
        //print(newPos);
    }
}
