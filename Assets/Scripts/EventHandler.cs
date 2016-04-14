using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour
{
    public GameObject[] events;
    public GameObject[] spawnLocation;

    public bool forced = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        GameObject child = null;
        if (player.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("EventEnter"))
            {
                EnterEvent(child);
                Destroy(this.gameObject);
            }
            else if (this.gameObject.CompareTag("EventExit"))
            {
                EventExit();
            }

        }

    }

    private void EnterEvent(GameObject child)
    {
        //random event
        if (!this.forced)
        {
            for (int i = 0; i <= spawnLocation.Length - 1; i++)
            {
                float rand = Random.value;
                GameObject spawnObject = null;
                //boss
                if (rand <= .1f)
                {
                    spawnObject = events[0];
                }
                //monster
                else if (rand < .8f && rand > .1f)
                {
                    spawnObject = events[1];
                }
                //cache
                else if (rand >= .8f)
                {
                    spawnObject = events[2];
                }
                child = Instantiate(spawnObject, spawnLocation[i].transform.position, Quaternion.identity) as GameObject;
                child.transform.parent = transform.parent;
            }
        }
        //forced boss event
        else {
            child = Instantiate(events[0], spawnLocation[0].transform.position, Quaternion.identity) as GameObject;
            child.transform.parent = transform.parent;
        }
    }

    private void EventExit()
    {
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
