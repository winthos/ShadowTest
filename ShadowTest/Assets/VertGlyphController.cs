using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertGlyphController : MonoBehaviour {

    /*public GameObject ShadowBurst = null;
	public GameObject ShadowOnWall = null;
	public GameObject ShadowOnFloor = null;

	public bool StartTheCountdown = false;

	public float Timer = 0.5f;
    */
    public GameObject symbol1 = null;
    public GameObject symbol2 = null;
    public GameObject symbol3 = null;

    public bool AmIBeingTargeted = false;

    public bool prism1 = false;
    public bool prism2 = false;
    public bool prism3 = true;
    
	// Use this for initialization
	void Start () 
	{
        //transform.GetComponent<LineRenderer>().enabled = false;

        symbol1.SetActive(false);
        symbol2.SetActive(false);
        symbol3.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () 
	{

        if(AmIBeingTargeted == true)
        {
            //    transform.GetComponent<LineRenderer>().enabled = true;
            //  transform.GetComponent<LineRenderer>().SetPosition(0, new Vector3(firstpos.transform.position.x, firstpos.transform.position.y, firstpos.transform.position.z));
            //   transform.GetComponent<LineRenderer>().SetPosition(1, new Vector3(secondpos.transform.position.x, secondpos.transform.position.y, secondpos.transform.position.z));

            if(prism1 == true)
            symbol1.SetActive(true);

            if(prism2 == true)
            symbol2.SetActive(true);

            if(prism3 == true)
            symbol3.SetActive(true);
        }

        if(AmIBeingTargeted == false)
        {
            // transform.GetComponent<LineRenderer>().enabled = false;
            symbol1.SetActive(false);
            symbol2.SetActive(false);
            symbol3.SetActive(false);
        }

        if (Input.GetMouseButtonUp(1))
        {
            AmIBeingTargeted = false;
        }

        /*
		if (StartTheCountdown == true)
		{
			Timer -= Time.deltaTime;
			if(Timer <= 0.0f)
			{
				ShadowBurst.SetActive(true);
				ShadowOnWall.SetActive(true);
				ShadowOnFloor.SetActive (true);
				StartTheCountdown = false;
				//Enemy.GetComponent<Renderer>().material.color = Color.white;
			}
				
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			ShadowBurst.SetActive(false);
			ShadowOnWall.SetActive(false);
			ShadowOnFloor.SetActive (false);
			Timer = 0.5f;
			//Enemy.GetComponent<Renderer>().material.color = Color.black;
		}*/
    }
}
