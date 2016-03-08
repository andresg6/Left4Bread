﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerControl : Character
{
    public float speed;
    public float walkingSpeed = 5;
    public float runningSpeed = 10;
    public float range;

    public bool isWalking = false;
    public bool isRunning = false;
    public bool loud = false;
    public bool splashy = false;
    public bool hidden = false;
    public bool invincible = false;
    public float timehit = 2;
    public float invincibleTime;
    int x;
    int y;
    Vector2 direction;

    public bool alert = false;
    public float alertPercentage = 0.0f;
    public float alertStep = 10.0f;
    public AudioSource alertMusic;

    private Animator anim;
    public MainUIController mainui;
    private string lastMovement;

        //void Start()
        //{
        //    Physics2D.IgnoreLayerCollision(0, 1, true);
        //}
	public override void Start()
    {
        base.Start();
        anim = this.GetComponent<Animator>();
        mainui = FindObjectOfType<MainUIController>();
        if(mainui)
        {
            mainui.updatePlayerHealth((int)health, (int)maxHealth);
        }
    }

    void Update()
    {
        if (alert)
        {
            alertMusic.enabled = true;
            alertMusic.loop = true;
        }
        else
        {
            alertMusic.enabled = false;
            alertMusic.loop = false;
        }
    }
  
	void FixedUpdate ()
    {
        Collider2D[] enemiesnearby = Physics2D.OverlapCircleAll(transform.position, range).Where(c => c.tag == "Enemies").ToArray();
        if (loud)
        {
            foreach (Collider2D enemy in enemiesnearby)
            {
                Vector3 targetDir = transform.position - enemy.transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, q, Time.deltaTime * speed);
            }
        }
        if (hidden)
        {
           player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        }
        else
        {
            player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        Movement();

        if (!isWalking && !isRunning)
        {
            anim.speed = 0;
        }

        else if (isWalking)
        {
            anim.speed = 1;
        }

        else if (isRunning)
        {
            anim.speed = 2;
        }

        if (invincible)
        {
            StartCoroutine("Flasher");
            if (timehit + invincibleTime < Time.realtimeSinceStartup)
            {
                invincible = false;
                //player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    IEnumerator Flasher()
    {
            player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(.1f);
            player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(.1f);
    }

    void Movement()
    {
        isWalking = false;
        isRunning = false;
        //loud = false;
        //Vector2 movement;
        x = 0;
        y = 0;
        if (!hidden)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;

            }

            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(Vector2.right * speed * Time.deltaTime);
                x++;
                isWalking = true;
                lastMovement = "walkingRight";
            }

            if (Input.GetKey(KeyCode.A))
            {
                ///transform.Translate(Vector2.left * speed * Time.deltaTime);
                x--;
                isWalking = true;
                lastMovement = "walkingLeft";
            }

            if (Input.GetKey(KeyCode.W))
            {
                // transform.Translate(Vector2.up * speed * Time.deltaTime);
                y++;
                isWalking = true;
                lastMovement = "walkingBack";
            }

            if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(Vector2.down * speed * Time.deltaTime);
                y--;
                isWalking = true;
                lastMovement = "walkingFront";
            }

            //animations
            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(Vector2.right * speed * Time.deltaTime);
                anim.Play("walkingRight");
            }

            else if (Input.GetKey(KeyCode.A))
            {
                ///transform.Translate(Vector2.left * speed * Time.deltaTime);
                anim.Play("walkingLeft");
            }

            else if (Input.GetKey(KeyCode.W))
            {
                // transform.Translate(Vector2.up * speed * Time.deltaTime);
                anim.Play("walkingBack");
            }

            else if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(Vector2.down * speed * Time.deltaTime);
                anim.Play("walkingFront");
            }


            if (isWalking && isRunning)
            {
                //player is holding down shift and W,A,S, or D
                loud = true;
                isWalking = false;
                speed = runningSpeed;
                range = 10;

            }
            if (isWalking)
            {
                //player is *not* holding down shift but is holding W,A,S,or D 
                loud = true;
                speed = walkingSpeed;
                range = 5;
            }

            direction.x = x;
            direction.y = y;
            transform.Translate(direction * speed * Time.deltaTime);
            if (splashy && isWalking)
            {
                range = 10;
                splashy = false;
            }
            if (splashy && isRunning)
            {
                range = 15;
                splashy = false;
            }
        }
    }
}
