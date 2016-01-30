using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class CanvasController : MonoBehaviour {
    public Image healthLeft;
    public Image healthMid;
    public Image healthRight;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void updatePlayerHealth(int currentHP)
    {
        //Hard-coded health to 3, requires re-write for variable health
        if (currentHP == 3)
        {
            healthLeft.gameObject.SetActive(true);
            healthMid.gameObject.SetActive(true);
            healthRight.gameObject.SetActive(true);
        }
        else if (currentHP == 2)
        {
            healthLeft.gameObject.SetActive(true);
            healthMid.gameObject.SetActive(true);
            healthRight.gameObject.SetActive(false);
        }
        else if (currentHP == 1)
        {
            healthLeft.gameObject.SetActive(true);
            healthMid.gameObject.SetActive(false);
            healthRight.gameObject.SetActive(false);
        }
        else //currentHP == 0
        {
            healthLeft.gameObject.SetActive(false);
            healthMid.gameObject.SetActive(false);
            healthRight.gameObject.SetActive(false);
        }
    }
}
