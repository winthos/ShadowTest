using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mylinerenderer : MonoBehaviour {

    public GameObject firstpos = null;
    public GameObject secondpos = null;
    // Use this for initialization
    void Start () {
        transform.GetComponent<LineRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.GetComponent<LineRenderer>().enabled = true;
          transform.GetComponent<LineRenderer>().SetPosition(0, new Vector3(firstpos.transform.position.x, firstpos.transform.position.y, firstpos.transform.position.z));
           transform.GetComponent<LineRenderer>().SetPosition(1, new Vector3(secondpos.transform.position.x, secondpos.transform.position.y, secondpos.transform.position.z));
    }
}
