using UnityEngine;
using System.Collections;

public class LightDetect2 : MonoBehaviour
{
    public bool detected = false;

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           Debug.Log("Enter");
            detected = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");

        detected = false;
    }
}
