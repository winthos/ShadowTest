using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public Color lanternColor = Color.white;
    [Range(0,1)]
    public float alpha = 0.5f;

    Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();

        lanternColor.a = alpha;
        rend.material.color = lanternColor;

        gameObject.tag = "ColorTrigger";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
