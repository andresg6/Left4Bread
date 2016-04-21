using UnityEngine;
using System.Collections;

public class playerCamera : Base {

	// Update is called once per frame
	void LateUpdate () 
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 6);
	}
}
