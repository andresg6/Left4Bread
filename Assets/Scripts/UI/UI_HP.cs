using UnityEngine;
using System.Collections;

public class UI_HP : MonoBehaviour {

    private bool isDying;
    private Animator anim;

	void Start () {
        isDying = true;
        anim = GetComponent<Animator>();
    }
	
	void Update () {
	    if(isDying)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
            {
                Debug.Log("Kill me yogi");
                Destroy(this.gameObject);
            }
        }
	}

    void lostAnimation()
    {
        anim.SetTrigger("Dead");
        isDying = true;
    }
}
