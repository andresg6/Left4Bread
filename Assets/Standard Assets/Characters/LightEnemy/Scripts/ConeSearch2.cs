using UnityEngine;
using System.Collections;
using System.Linq;

public class ConeSearch2 : MonoBehaviour
{
    public float speed = 2.0f;
    //public bool detected = false;
    public Transform range1, range2, range3;

    // Update is called once per frame
    void Update()
    {

        Transform player = GameObject.FindWithTag("Player").transform;

        //Light l = GetComponentInChildren<Light>();
        //float range = l.range;
        //float scope = l.spotAngle;

        //Vector3 targetDir = player.position - transform.position;
        //float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        //Vector3 t = transform.eulerAngles;
        //float angle2 = Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg;

        //Debug.Log("Player: " + angle);
        //Debug.Log("ENEMY: " + transform.rotation.z * 180 + scope/2);
        //Debug.Log((((transform.rotation.z * 180) + scope) / 2) - angle);
        //Debug.Log((((transform.rotation.z * 180) - scope) / 2) - angle);
        //Debug.DrawRay(transform.position, range1.position, Color.cyan, 20, true);
        //Debug.DrawLine(transform.position, range1.position, Color.cyan);

        //float angle2 = transform.rotation.z * 180;
        //if (Vector3.Distance(transform.position, player.position) <= range)
        //{
        //    if (angle <= angle2 + scope/2 && angle >= angle2-scope/2)
        //    {
        //        //RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position);

        //Vector3 temp = range1.position;
        //for (int i = 0; i < 100; i++)
        //{
        //    Debug.DrawLine(range2.position, temp);
        //    RaycastHit2D hit = Physics2D.Linecast(range2.position, temp);

        //    if (hit.collider != null)
        //    {
        //        if (hit.collider.tag == "Player")
        //        {
        //            detected = true;
        //        }
        //    }

        //    temp = new Vector3(temp.x, temp.y - .01f, temp.z);
        //}




        //    }
        //}

        //else
        //{
        //    detected = false;
        //}

        LightDetect2 l = GetComponentInChildren<LightDetect2>();

        if (player != null)
        {
            if (l.detected)
            {
                Movement(player);
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
