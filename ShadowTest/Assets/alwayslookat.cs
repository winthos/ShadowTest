﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwayslookat : MonoBehaviour {

    public Transform target = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.LookAt(target);
    }
}
