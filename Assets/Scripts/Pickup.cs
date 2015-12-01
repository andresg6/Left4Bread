using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerControl p = other.gameObject.GetComponent<PlayerControl>();
            p.speed++;
            gameObject.SetActive(false);
            
        }
    }
}