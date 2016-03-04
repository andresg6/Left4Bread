using UnityEngine;
using System.Collections;

public class MushBoom : Character
{
    public string direction;
    public GameObject Spore;
    public int frequency = 3; //times per second mushboom shoots
    private double interval;
    private double timeLeft;
    public float shootOffset = 0.0f;


    // Use this for initialization
    public override void Start()
    {
        base.Start();
        maxHealth = 1;
        team = 1;
       // direction = "right";
        health = maxHealth;
        interval = (double)1 / frequency;
        timeLeft = interval;


    }



    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (health <= 0.0f)
        {
            gameObject.SetActive(false);
        }
        timeLeft -= Time.deltaTime;
       // Debug.Log(timeLeft);
        if (timeLeft <= 0.0)
        {
            timeLeft = interval;
            Shoot();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        if (otherCharacter != null && otherCharacter.team != this.team)
        {
            OnCollision(otherCharacter);
        }

        Pickup otherPickup = other.GetComponent<Pickup>();
        if (otherPickup != null)
        {
            OnPickup(otherPickup);
        }
    }

    void Shoot()
    {   
         GameObject go = Instantiate(Spore);
         go.GetComponent<Spore>().direction = this.direction;
         Vector2 shootFrom = new Vector2(transform.position.x, transform.position.y + shootOffset);
         go.transform.position = shootFrom;

    }
    public virtual void OnPickup(Pickup other)
    {
    }

    public virtual void OnCollision(Character other)
    {
    }

    public virtual void OnCollisionStay2D(Collision2D other)
    {
    }
}
