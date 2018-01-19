using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingStone : MonoBehaviour
{
    public bool standingStoneSet = false;
    public StandingStone_target target;
    public StandingStone_trigger trigger;

	// Use this for initialization
	void Start ()
    {
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ConditionsMet();
	}

    public bool ConditionsMet()
    {
        if(target.stoneActive && trigger.triggerActive)
        {
            standingStoneSet = true;
        }
        else
        {
            standingStoneSet = false;
        }

        return standingStoneSet;
    }


}
