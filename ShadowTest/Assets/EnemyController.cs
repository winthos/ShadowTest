using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;

    public bool StopMoving = false;
    public float HowLongAmIStunned = 10.0f;


    // Use this for initialization
    void Start () {
        min = transform.position.x;
        max = transform.position.x + 15;


    }
	
	// Update is called once per frame
	void Update () {

        if(StopMoving == false)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time* 2, max - min) + min, transform.position.y, transform.position.z);
        }

        if(StopMoving == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StopMoving = false;
            }
        }

        

    }
}
