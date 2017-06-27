using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMover : MonoBehaviour 
{

	public Transform thingImLookingAt;

	public bool AmILockedOnToTheThing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (AmILockedOnToTheThing == false) 
		{

			Quaternion quattro = Quaternion.LookRotation (GameObject.Find ("Pivot").transform.forward,GameObject.Find ("Pivot").transform.up );
			gameObject.transform.rotation = quattro;
			//print (quattro);
		}

		if (AmILockedOnToTheThing == true) 
		{
			gameObject.transform.LookAt (thingImLookingAt);
		}

		if (Input.GetKey (KeyCode.W)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * 10);
		}

		if (Input.GetKey (KeyCode.A)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.right * -10);
		}

		if (Input.GetKey (KeyCode.S)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * -10);
		}

		if (Input.GetKey (KeyCode.D)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.right * 10);
		}

		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)) 
		{
			gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}


		if(Input.GetMouseButton(1))
			{
				RaycastHit hit;

				if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20))
				{
					//print ("I Touched Something");
					if (hit.transform.tag == "ThingICanLockOnTo") 
					{
						//print ("I Touched Cube 5)");

					    AmILockedOnToTheThing = true;
					    thingImLookingAt = hit.transform;

					}
				}
			}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			AmILockedOnToTheThing = false;
		}


	}
}
