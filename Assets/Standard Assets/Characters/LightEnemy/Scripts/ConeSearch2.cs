using UnityEngine;
using System.Collections;
using System.Linq;

public class ConeSearch2 : MonoBehaviour
{

    public float range;
    public float angle;
    public float speed = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform player = GameObject.FindWithTag("Player").transform;

        
        LightDetect2 detect = GetComponentInChildren<LightDetect2>();

        if (detect.detected)
        {
            Movement(player);
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
}
