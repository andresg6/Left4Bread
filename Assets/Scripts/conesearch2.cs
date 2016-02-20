using UnityEngine;
using System.Collections;
using System.Linq;

public class conesearch2 : Character
{
    public float speed = 2.0f;
    public bool alert = false;
    float alertPercentage = 0.0f;
    float alertStep = 10.0f;

    void FixedUpdate()
    {
        if (player.gameObject.activeSelf)
        {
            LightDetect2 l = GetComponentInChildren<LightDetect2>();
            //Debug.Log(alertPercentage);

            if (l.detected)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 99999, LayerMask.GetMask("Test"));
                if (hit.collider.tag == "Player")
                {
                    //Debug.Log("RESET");
                    alert = true;
                    alertPercentage = 100.0f;
                    //Movement(player.transform);
                }
            }

            else
            {
                alertPercentage -= alertStep * Time.deltaTime;

                if (alertPercentage <= 0.0f)
                {
                    alert = false;
                    alertPercentage = 0.0f;
                }
            }
            if (alert)
            {
                Movement(player.transform);
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

    public override void OnCollision(Character other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            //Debug.Log(this.collisionDamage);
            if (!other.gameObject.GetComponent<PlayerControl>().invincible)
            {
                other.health -= this.collisionDamage;
                other.gameObject.GetComponent<PlayerControl>().invincible = true;
                other.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
            }
        }
    }

    public override void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            if (!other.gameObject.GetComponent<PlayerControl>().invincible)
            {
                other.gameObject.GetComponent<PlayerControl>().health -= this.collisionDamage;
                other.gameObject.GetComponent<PlayerControl>().invincible = true;
                other.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
            }
        }
    }
}
