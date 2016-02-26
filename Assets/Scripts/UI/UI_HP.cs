using UnityEngine;
using System.Collections;

public class UI_HP : MonoBehaviour {

    private bool isDying;
    private Animator anim;

	void Start () {
        isDying = true;
        anim = GetComponent<Animator>();
    }

    public void removeHealth()
    {
        lostAnimation();
    }
	
	void Update () {
	    if(isDying)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
            {
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
