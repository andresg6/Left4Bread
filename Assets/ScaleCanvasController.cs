using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleCanvasController : MonoBehaviour {

    public Text TaskText;
    public RectTransform TextPanel;
    private bool isHidden;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        moveScaledItems();
	}

    private void moveScaledItems()
    {
        if (!isHidden)
        {
            
        }
    }
}
