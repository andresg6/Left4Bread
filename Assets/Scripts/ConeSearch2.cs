using UnityEngine;
using System.Collections;
using System.Linq;

public class ConeSearch2 : MonoBehaviour
{

    public float range;
    public float angle;
    public float speed = 2.0f;
    public bool seeTarget = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Collider2D[] PlayersNearMe = Physics2D.OverlapCircleAll(transform.position, range).Where(c => c.tag == "Player").ToArray();
        if (PlayersNearMe.GetLength(0) > 0)
        {
            seeTarget = true;
        }
        else
        {
            seeTarget = false;
        }

        if (seeTarget)
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
