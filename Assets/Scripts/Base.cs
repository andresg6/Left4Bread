using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour 
{
    public PlayerControl player;
    
	// Use this for initialization
	public virtual void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();	
	}
	
	// Update is called once per frame
	public virtual void Update () 
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        }
	}
}
