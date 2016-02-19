using UnityEngine;

public class Puddle : Environment
{

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            isInteracting = true;
            player.splashy = true;
        }

    }
}
