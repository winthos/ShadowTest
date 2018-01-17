using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMover : MonoBehaviour 
{

	public Transform thingImLookingAt;

	public bool AmILockedOnToTheThing = false;

    private bool StopMoving = false;

    public GameObject ForwardLight = null;

    public GameObject RoundLamp = null;

    public GameObject LightTargeting = null;

    public GameObject StunLight = null;

    private float StunTimer = 2.0f;
    private bool StartStunTimer = false;

   // public GameObject ShadowBlast = null;
    //public GameObject Sparks = null;
    //public GameObject Shockwave = null;
    public GameObject CastShadowLightParticle = null;
    public GameObject BrightForwardLamp = null;

   // public GameObject Glyph = null;

	//public GameObject EnviroGlyphHoriz = null;
	//public GameObject EnviroGlyphShadowCast = null;

	//public GameObject EnviroGlyphOther = null;
	//public GameObject EnviroGlyphShadowCastOther = null;

   // public GameObject Enemy = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (AmILockedOnToTheThing == false) 
		{
            //thingImLookingAt.GetComponent<VertGlyphController>().AmIBeingTargeted = false;
            Quaternion quattro = Quaternion.LookRotation (GameObject.Find ("Pivot").transform.forward,GameObject.Find ("Pivot").transform.up );
			gameObject.transform.rotation = quattro;
			//print (quattro);
		}

		if (AmILockedOnToTheThing == true) 
		{
			gameObject.transform.LookAt (thingImLookingAt);
            thingImLookingAt.GetComponent<VertGlyphController>().AmIBeingTargeted = true;
		}

		if (Input.GetKey (KeyCode.W)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * 10);
            StopMoving = false;
		}

		if (Input.GetKey (KeyCode.A)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.right * -10);
            StopMoving = false;
        }

		if (Input.GetKey (KeyCode.S)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * -10);
            StopMoving = false;
        }

		if (Input.GetKey (KeyCode.D)) {

			gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.right * 10);
            StopMoving = false;
        }

		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)) 
		{
            //print("stop moving");
			gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
            StopMoving = true;
		}

        if(StopMoving == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
			

        if(StartStunTimer == true)
        {
            StunTimer -= Time.deltaTime;
            if(StunTimer <= 0.0f)
            {
                StunLight.SetActive(false);
                StartStunTimer = false;
                StunTimer = 2.0f;
            }
        }

/////////////////////////MOOOUUUUSSSEEE STUFFFFFFF HEEEEERE

		//if you put down left click
		/*if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) == false)
		{
			StunLight.SetActive(true);
			StartStunTimer = true;

			Enemy.GetComponent<EnemyController>().StopMoving = true;
		}*/
        
        //hold down right click, turn on the targeting light
		if(Input.GetMouseButton(1))
			{
				RaycastHit hit;

                ForwardLight.SetActive(true);
                RoundLamp.SetActive(false);
                LightTargeting.SetActive(true);

				if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20))
				{
					//print ("I Touched Something");
					if (hit.transform.tag == "ThingICanLockOnTo") 
					{
						//print ("I Touched Cube 5)");

					    AmILockedOnToTheThing = true;
					    thingImLookingAt = hit.transform;

                    hit.transform.forward = gameObject.transform.forward;

                        //if right click is held down, we have a target, let's try and BLAST IT

                       /* if(Input.GetMouseButton(0))
                        {
                            //ShadowBlast.SetActive(true);
                            //Shockwave.SetActive(true);
                            //Sparks.SetActive(true);
                            CastShadowLightParticle.SetActive(true);
                            BrightForwardLamp.SetActive(true);

                            Glyph.GetComponent<GlyphController>().StartTheCountdown = true;
							EnviroGlyphHoriz.GetComponent<VertGlyphController> ().StartTheCountdown = true;
							EnviroGlyphShadowCast.SetActive (true);

							EnviroGlyphOther.GetComponent<HorizGlyphController> ().StartTheCountdown = true;
							EnviroGlyphShadowCastOther.SetActive (true);
							
                        }*/
                    }
                }

                

			}

        //release right click, stuff happens
        if(Input.GetMouseButtonUp(1))
        {
            ForwardLight.SetActive(false);
            RoundLamp.SetActive(true);
            AmILockedOnToTheThing = false;
            LightTargeting.SetActive(false);

            //ShadowBlast.SetActive(false);
            //Shockwave.SetActive(false);
            //Sparks.SetActive(false);
            CastShadowLightParticle.SetActive(false);
            BrightForwardLamp.SetActive(false);

			//EnviroGlyphShadowCast.SetActive (false);

			//EnviroGlyphOther.GetComponent<HorizGlyphController> ().StartTheCountdown = true;
			//EnviroGlyphShadowCastOther.SetActive (false);
        }


	}
}
