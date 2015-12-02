using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;


        //void Start()
        //{
        //    Physics2D.IgnoreLayerCollision(0, 1, true);
        //}
	// Update is called once per frame
	void Update ()
    {
        Movement();	
	}

    void Movement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
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
}
