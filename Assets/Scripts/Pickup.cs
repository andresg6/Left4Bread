using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}