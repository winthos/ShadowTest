using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTheGlyphDamnYou : MonoBehaviour {

    public GameObject Glyph = null;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.LookAt(Glyph.GetComponent<Transform>().position);
	}
}
