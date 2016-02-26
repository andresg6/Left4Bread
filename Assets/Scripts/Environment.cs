using UnityEngine;
using System.Collections;

public class Environment : Base
{
    public bool isInteracting;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        isInteracting = false;

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            isInteracting = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("Test"))
        {
            isInteracting = false;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }


}