using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleCanvasController : MonoBehaviour {

    public Text TaskText;
    public RectTransform TextPanel;
    private bool isHidden;

    private float lastTimescale;


	// Use this for initialization
	void Start () {
        isHidden = true;
	}
	
	// Update is called once per frame
	void Update () {
        moveScaledItems();
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

    public void toggleInfoPanel()
    {
        isHidden = !isHidden;
    }

    public void pauseGame()
    {
        lastTimescale = Time.timeScale;
        Time.timeScale = 0.0f;
    }

    public void unpauseGame()
    {
        Time.timeScale = lastTimescale;
    }
}
