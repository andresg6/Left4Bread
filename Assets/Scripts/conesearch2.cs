using UnityEngine;
using System.Collections;
using System.Linq;

public class conesearch2: MonoBehaviour
{

    public float range;
    public float angle;
    public float speed = 2.0f;
    public bool seeTarget = false;
    bool alert = false;
    float alertPercent = 0.0f;
    float alertPercentStep = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(alertPercent);
        Transform player = GameObject.FindWithTag("Player").transform;
        Collider2D[] PlayersNearMe = Physics2D.OverlapCircleAll(transform.position, range).Where(c => c.tag == "Player").ToArray();
        if (PlayersNearMe.GetLength(0) > 0)
        {
            seeTarget = true;
            alert = true;
            alertPercent = 100.0f;
        }
        else
        {
            if (alert)
            {
                alertPercent -= alertPercentStep * Time.deltaTime;
                if (alertPercent <= 0.0f)
                {
                    alert = false;
                    alertPercent = 0.0f;
                }

                else
                {
                    alertPercent = 0.0f;
                }

                seeTarget = false;
            }

           
        }
        if (alert)
        {
            Movement(player);
        }
       

    }

    void Movement(Transform player)
    {
        if (Vector2.Distance(transform.position, player.position) > 1f)
        {
            transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y), player.position, speed * Time.deltaTime);
        }
    }
}
