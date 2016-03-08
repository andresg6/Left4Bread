using UnityEngine;
using System.Collections;
using System.Linq;

public class conesearch2 : Character
{
    public float speed = 2.0f;
 
    Vector3 startPos;

    public override void Start()
    {
        base.Start();
        startPos.x = transform.position.x;
        startPos.y = transform.position.y;
        startPos.z = transform.position.z;
    }

    void FixedUpdate()
    {
        if (player.gameObject.activeSelf)
        {
            LightDetect2 l = GetComponentInChildren<LightDetect2>();
            //Debug.Log(alertPercentage);

            if (l.detected && !player.hidden)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 99999, LayerMask.GetMask("Test"));
                if (hit.collider.tag == "Player")
                {
                    //Debug.Log("RESET");
                    player.alert = true;
                    player.alertPercentage = 100.0f;
                    //Movement(player.transform);
                }
            }

            else
            {
                player.alertPercentage -= player.alertStep * Time.deltaTime;

                if (player.alertPercentage <= 0.0f)
                {
                    player.alert = false;
                    player.alertPercentage = 0.0f;
                }
            }
            if (player.alert)
            {
                Movement(player.transform.position);
            }
            else
            {
                Debug.Log("not alerted, should be moving towards start position");
                Debug.Log(startPos.x);
                Debug.Log(startPos.y);
                Movement(startPos);
            }
        }
    }

    void Movement(Vector3 position)
    {
        if (Vector2.Distance(transform.position, position) > 1f)
        {
            Vector3 targetDir = position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
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
               // Debug.Log(player.health);
                other.gameObject.GetComponent<PlayerControl>().health -= this.collisionDamage;
                other.gameObject.GetComponent<PlayerControl>().invincible = true;
                other.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
            }
        }
    }
}
