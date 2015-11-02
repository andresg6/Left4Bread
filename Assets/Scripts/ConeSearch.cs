using UnityEngine;
using System.Collections;
using System.Linq;

public class ConeSearch : MonoBehaviour {

    public float range;
    public float angle;
    public bool seeTarget = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Collider2D[] PlayersNearMe = Physics2D.OverlapCircleAll(transform.position, range).Where(c => c.tag == "Player").ToArray();
        if (PlayersNearMe.GetLength(0) > 0)
        {
            seeTarget = true;
        }
        else
        {
            seeTarget = false;
        }

	}
}
