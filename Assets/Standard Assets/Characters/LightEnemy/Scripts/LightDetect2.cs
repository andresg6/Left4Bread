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
        //if (other.gameObject.tag == "Player")
        //{
        //    RaycastHit2D hit = Physics2D.Linecast(transform.position, other.transform.position);

        //    if (hit.collider.tag == "Player")
        //    {
        //        detected = true;
        //    }
        //}

        if (other.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        detected = false;
    }
}
