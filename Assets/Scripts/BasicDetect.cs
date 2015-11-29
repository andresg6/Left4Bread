using UnityEngine;
using System.Collections;

public class BasicDetect : MonoBehaviour {

    public bool detected = false;

	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Renderer renderer = GetComponent<Renderer>();
            detected = true;
            renderer.enabled = false;
        }
    }
}
