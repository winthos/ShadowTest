﻿using UnityEngine;
using System.Collections;

public class LaserScript_winson : MonoBehaviour
{
	public LineRenderer laserLineRenderer;
	public float laserWidth = 0.1f;
	public float laserMaxLength = 5f;

	void Start() {
		Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
		laserLineRenderer.SetPositions( initLaserPositions );
		laserLineRenderer.SetWidth( laserWidth, laserWidth );
	}

	void Update() 
	{
		if( Input.GetMouseButton(1) ) {
			ShootLaserFromTargetPosition( transform.position, gameObject.transform.forward, laserMaxLength );
			laserLineRenderer.enabled = true;
		}
		else {
			laserLineRenderer.enabled = false;
		}
	}

	void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
	{
		Ray ray = new Ray( targetPosition, direction );
		RaycastHit raycastHit;
		Vector3 endPosition = targetPosition + ( length * direction );

		if( Physics.Raycast( ray, out raycastHit, length ) ) {
			endPosition = raycastHit.point;
		}

		laserLineRenderer.SetPosition( 0, targetPosition );
		laserLineRenderer.SetPosition( 1, endPosition );
	}
}