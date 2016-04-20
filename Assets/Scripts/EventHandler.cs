using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour
{
    public GameObject[] events;
    public GameObject[] spawnLocation;


    void OnTriggerEnter2D(Collider2D player)
    {
        GameObject child = null;
        if (player.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("EventEnter"))
            {
                EnterEvent(child);
                //Destroy(this.gameObject);
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
        {
            for (int i = 0; i <= spawnLocation.Length - 1; i++)
            {
                float rand = Random.value;
                GameObject spawnObject = null;
                if (rand <= .5)
                {
                    spawnObject = events[0];
                }
                else if (rand > .5)
                {
                    spawnObject = events[1];
                }
                child = Instantiate(spawnObject, spawnLocation[i].transform.position, Quaternion.identity) as GameObject;
                child.transform.parent = transform.parent.FindChild("Monsters");
            }
        }
    }

    private void EventExit()
    {
        int childCount = this.transform.parent.FindChild("Monsters").childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.parent.FindChild("Monsters").GetChild(i).gameObject);
        }
    }
}
