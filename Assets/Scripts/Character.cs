using UnityEngine;
using System.Collections;

public class Character : Base 
{
    public int health;
    public int maxHealth;
    public int team;
    public int collisionDamage;

	// Use this for initialization
	public override void Start () 
    {
        base.Start();
        if (maxHealth <= 0)
        {
            maxHealth = 5;
        }

        health = maxHealth;
	}
	
	// Update is called once per frame
	public override void Update () 
    {
        base.Update();
        if (health <= 0.0f)
        {
            gameObject.SetActive(false);
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
