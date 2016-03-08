using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleCanvasController : MonoBehaviour {

    public Text TaskText;
    public RectTransform TextPanel;
    private bool isHidden;


	// Use this for initialization
	void Start () {
        isHidden = true;
	}
	
	// Update is called once per frame
	void Update () {
        handleKeyPress();
        moveScaledItems();
	}

    private void handleKeyPress()
    {
        if (Input.GetButtonDown("Info"))
        {
            isHidden = false;
        }
        if (Input.GetButtonUp("Info"))
        {
            isHidden = true;
        }
    }

    private void moveScaledItems()
    {
        if (!isHidden)
        {
            TaskText.gameObject.SetActive(true);
            TextPanel.gameObject.SetActive(true);
        }
        else
        {
            TaskText.gameObject.SetActive(false);
            TextPanel.gameObject.SetActive(false);
        }
    }
}
