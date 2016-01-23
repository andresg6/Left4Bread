using UnityEngine;
using System.Collections;
using System.Linq;

public class ConeSearch2 : MonoBehaviour
{
    public float speed = 2.0f;
    public float range = 5.0f;

    void FixedUpdate()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Transform player = GameObject.FindWithTag("Player").transform;

            LightDetect2 l = GetComponentInChildren<LightDetect2>();

            if (player != null)
            {
                if (l.detected)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, 99999, LayerMask.GetMask("Test"));
                    if (hit.collider.tag == "Player")
                    {
                        Movement(player);
                    }
                }
            }
            }
    }

    void Movement(Transform player)
    {
        if (Vector2.Distance(transform.position, player.position) > 1f)
        {
            Vector3 targetDir = player.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }
    }
}
