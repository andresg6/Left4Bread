using UnityEngine;
using System.Collections;

public class AndrewPlayerControl : MonoBehaviour
{

    float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
