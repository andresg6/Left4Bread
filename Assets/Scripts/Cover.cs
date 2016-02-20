using UnityEngine;

public class Cover : Environment
{


    public void Update()
    {
        if(isInteracting){
            if (Input.GetKey(KeyCode.E)){
            Debug.Log("in cover");
            player.hidden = true;
            }
            else
            {
                player.hidden = false;
            }
        }
    else
        {
            player.hidden = false;
        }
    }

   /* public void OnTriggerStay2D(Collider2D other)
    {

        
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test")  )
        {
            Debug.Log("in trigger");
            if (Input.GetKey(KeyCode.E))
            {
               
                ///put shit in for colliding with a cone of sight and have bools for "cover" and "hidden" bc you can be covered but they KNOW 
            }
            else
            {
                isInteracting = false;
                player.hidden = false;
                Debug.Log("out of cover");

            }
        }

    }*/
}
