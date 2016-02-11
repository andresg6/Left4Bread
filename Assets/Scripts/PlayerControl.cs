using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerControl : Character
{
    public float speed;
    public float range;

    public bool isWalking;
    public bool isRunning;
    public bool loud = false;
    public bool splashy = false;
    int x;
    int y;
    Vector2 direction;

    private Animator anim;
        //void Start()
        //{
        //    Physics2D.IgnoreLayerCollision(0, 1, true);
        //}
	public override void Start()
    {
        base.Start();
        anim = this.GetComponent<Animator>();
    }

    void onCollisionStay(Collision2D col)
    {
        if (col.gameObject.tag == "Puddles")
        {
            splashy = true;
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
        Movement();	
	}

    void Movement()
    {
        isWalking = false;
        isRunning = false;
        //Vector2 movement;
        x = 0;
        y = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;

        }
   
        
        if(Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            x++; 
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            ///transform.Translate(Vector2.left * speed * Time.deltaTime);
            x--;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
           // transform.Translate(Vector2.up * speed * Time.deltaTime);
            y++;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(Vector2.down * speed * Time.deltaTime);
            y--;
            isWalking = true;
        }
        if (isWalking && isRunning)
        {
            //player is holding down shift and W,A,S, or D
            isWalking = false;
            speed = 10;
            range = 10;
            
        }
        if (isWalking)
        {
            //player is *not* holding down shift but is holding W,A,S,or D 
            speed = 5;
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

    //public override void OnCollision(Character other)
    //{
    //    if (this.gameObject.layer == LayerMask.NameToLayer("Test"))
    //    {
    //        float damage = other.collisionDamage;
    //        Debug.Log(damage);
    //        health -= damage;
    //    }
    //}
}
