using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{

    float speed = 5.0f;
    

    // Update is called once per frame
    void Update()
    {
        BasicDetect detection = GameObject.Find("Enemy Vision 1").GetComponent<BasicDetect>();

        if (GameObject.FindWithTag("Player") != null)
        {
            if (detection.detected)
            {
                Transform player = GameObject.FindWithTag("Player").transform;
                Movement(player);
            }
        }
        
    }

    void Movement(Transform player)
    {
        if (Vector2.Distance(transform.position, player.position) > 1f)
        {
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
            
            //if (Time.deltaTime == 3)
            //{
            //    transform.Translate(Vector2.right * speed * 3);
            //}

            //transform.Translate(Vector2.MoveTowards(transform.position, player.position, 1));
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Collider collider = GameObject.Find("Enemy Vision 1").gameObject.GetComponent<Collider>();
        if (!collider.enabled)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SetActive(false);
            }
        }
        
    }
}
