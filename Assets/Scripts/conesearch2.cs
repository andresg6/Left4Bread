using UnityEngine;
using System.Collections;
using System.Linq;

public class conesearch2 : Character
{
    public float speed = 5.0f;
    public float maxspeed = 15.0f;
    public bool alert = false;
    public bool invincible = false;
    public float timehit;
    public float invincibleTime = 1;
    float alertPercentage = 0.0f;
    float alertStep = 10.0f;
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
                Debug.DrawRay(transform.position, player.transform.position - transform.position);
                if (hit.collider.tag == "Player")
                {
                    //Debug.Log("DETECTED");
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
                //Debug.Log("not alerted, should be moving towards start position");
                //Debug.Log(startPos.x);
                //Debug.Log(startPos.y);
                Movement(startPos);
            }
        }
       
        if (invincible)
        {
            StartCoroutine("Flasher");
        }

        if (timehit + invincibleTime < Time.realtimeSinceStartup)
        {
            invincible = false;
            speed = maxspeed;
        }
    }

    IEnumerator Flasher()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(.1f);
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
                player.gameObject.GetComponent<PlayerControl>().invincible = true;
                other.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
                player.mainui.updatePlayerHealth(player.health, player.maxHealth);
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
                other.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
                player.gameObject.GetComponent<PlayerControl>().invincible = true;
                player.mainui.updatePlayerHealth(player.health, player.maxHealth);
            }
        }
    }
}
