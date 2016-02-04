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

	void FixedUpdate ()
    {
        isWalking = anim.GetBool("isWalking");
        isRunning = anim.GetBool("isRunning");
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
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    public override void OnCollision(Character other)
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            float damage = other.collisionDamage;
            Debug.Log(damage);
            health -= damage;
        }
    }
}
