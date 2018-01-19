using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Lantern : MonoBehaviour
{
    //public ThirdPersonUserControl userControl;
    //CameraController camControl;

    public GameObject player;

    public bool showLineRenderer = true;
    LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    Vector3 endPosition;

    public Color lanternColor = Color.magenta;
    public Light pointlite;
    public Light spotlite;
    public Transform objectAnchor;
    Renderer rend;

    GameObject lanternTarget;
    public bool moving;

    public Magnesis magnetObj;


	// Use this for initialization
	void Start ()
    {
        //camera
        //camControl = Camera.main.GetComponent<CameraController>();

        //raycast
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };

        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.material.color = lanternColor;

        TurnOnPointLight(false);
        TurnOnSpotlight(false);
        
        //lantern
        rend = GetComponent<Renderer>();
        UpdateLanternColor(lanternColor);

        moving = false;

    }
    
    void TurnOnPointLight(bool _on)
    {
        pointlite.enabled = _on;
    }

    void TurnOnSpotlight(bool _on)
    {
        if(showLineRenderer)
            laserLineRenderer.enabled = _on;
        spotlite.enabled = _on;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColorTrigger"))
        {
            lanternColor = other.gameObject.GetComponent<ColorTrigger>().lanternColor;
            UpdateLanternColor(lanternColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //TurnOnPointLight(false);
            TurnOnSpotlight(true);
            if (laserLineRenderer != null)
                ShootLaserFromTargetPosition(transform.position, transform.forward, laserMaxLength);

            objectAnchor.transform.position = transform.position + transform.forward;
        }
        else
        {
            moving = false;
            //TurnOnPointLight(true);
            TurnOnSpotlight(false);
            
        }

        if (moving && magnetObj != null)
        {
            magnetObj.MoveObject(endPosition);
        }

    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        endPosition = targetPosition + (Mathf.Max(4, length) * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
            //print(endPosition);
            //objectAnchor.transform.position = endPosition;

            if (raycastHit.collider.CompareTag("StoneTarget") && lanternTarget == null)
            {
                lanternTarget = raycastHit.transform.gameObject;
                lanternTarget.GetComponent<StandingStone_target>().stoneActive = true;
            }
            else if ((raycastHit.collider.tag != "StoneTarget" || raycastHit.collider.tag == null) && 
                lanternTarget != null)
            {
                lanternTarget.GetComponent<StandingStone_target>().stoneActive = false;
                lanternTarget = null;
            }
            else if (raycastHit.collider.tag == "MovingObject")
            {
                magnetObj = raycastHit.collider.transform.parent.gameObject.GetComponent<Magnesis>();
                if (objectAnchor != null)
                {
                    moving = true;
                    magnetObj.MoveObject(endPosition);
                }
            }
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }

    void LockOntoTarget()
    {
    }

    void UpdateLanternColor(Color _color)
    {
        Color c = _color;
        c.a = 1f;

        laserLineRenderer.material.color = c;
        rend.material.color = c;
        pointlite.color = c;
        spotlite.color = c;
    }


}
