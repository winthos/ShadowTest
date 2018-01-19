using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingStone_trigger : MonoBehaviour {

    public bool triggerActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            triggerActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            triggerActive = false;
    }
}
