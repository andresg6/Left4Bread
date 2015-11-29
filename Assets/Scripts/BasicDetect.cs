﻿using UnityEngine;
using System.Collections;

public class BasicDetect : MonoBehaviour {

    public bool detected = false;

	// Update is called once per frame
	void Update () 
    {
        if (detected)
        {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.enabled = false;

            detected = true;
        }
    }
}
