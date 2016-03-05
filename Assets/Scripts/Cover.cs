using UnityEngine;

public class Cover : Environment
{


    public void Update()
    {
        if(isInteracting){
            if (Input.GetKey(KeyCode.E)){
            Debug.Log("in cover");
            player.hidden = true;
            player.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                player.hidden = false;
                player.gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
    else
        {
            player.hidden = false;
        }
    }

  
}
