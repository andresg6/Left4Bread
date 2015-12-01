using UnityEngine;
using System.Collections;

public class LightEnemy : MonoBehaviour
{

    float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        LightDetect detection = GameObject.Find("Enemy Light").GetComponent<LightDetect>();

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
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Collider collider = GameObject.Find("Enemy Light").gameObject.GetComponent<Collider>();
        if (!collider.enabled)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SetActive(false);
            }
        }

    }
}
