using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    public Color lineColor = Color.magenta;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.material.color = lineColor;

        laserLineRenderer.enabled = true;
    }
    
    void Update()
    {
        if(laserLineRenderer != null)
            ShootLaserFromTargetPosition(transform.position, transform.forward, laserMaxLength);

        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{ 
        //    ShootLaserFromTargetPosition(transform.position, Vector3.forward, laserMaxLength); 
        //    laserLineRenderer.enabled = true; 
        //} 
        //else 
        //{ 
        //    laserLineRenderer.enabled = false; 
        //} 
    }
    
    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}