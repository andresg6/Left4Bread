using UnityEngine;
using System.Collections;

public class Spore : Base
{
   
    public string direction;
    public int speed = 20;
    public int damage = 5;
    
	// Use this for initialization
	public virtual void Start () 
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();	

	}
	
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Player"){
           
            if (!player.invincible)
            {
                coll.gameObject.GetComponent<PlayerControl>().health -= this.damage;
                coll.gameObject.GetComponent<PlayerControl>().invincible = true;
                coll.gameObject.GetComponent<PlayerControl>().timehit = Time.realtimeSinceStartup;
                
            }
        }
        Debug.Log("collided");
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	public virtual void Update () 
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            
        }
        if (direction == "N")
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (direction == "S")
        {
            transform.Translate(Vector2.down* speed * Time.deltaTime);
        }
        else if (direction == "W")
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (direction == "E")
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
	}
}
