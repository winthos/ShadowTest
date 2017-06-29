using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphController : MonoBehaviour {

    public GameObject ShadowBurst = null;
    public GameObject ShadowOnWall = null;

    public bool StartTheCountdown = false;

    public float Timer = 0.5f;

    public GameObject Enemy = null;



	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {



        if (StartTheCountdown == true)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0.0f)
            {
                ShadowBurst.SetActive(true);
                ShadowOnWall.SetActive(true);
                StartTheCountdown = false;
                Enemy.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            ShadowBurst.SetActive(false);
            ShadowOnWall.SetActive(false);
            Timer = 0.5f;
            Enemy.GetComponent<Renderer>().material.color = Color.black;
        }
	}
}
