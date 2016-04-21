using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleCanvasController : MonoBehaviour
{

    public Text TaskText;
    public RectTransform TextPanel;

    public RectTransform blackout;
    public RectTransform pausePanel;
    public Text pauseText;
    public Button resume;
    public Button quit;

    private bool isHidden;

    private float lastTimescale;
    private bool isPaused;

    // Use this for initialization
    void Start()
    {
        isHidden = true;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
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

    private void setPauseGroupActive(bool newActiveState)
    {
        blackout.gameObject.SetActive(newActiveState);
        pausePanel.gameObject.SetActive(newActiveState);
        pauseText.gameObject.SetActive(newActiveState);
        resume.gameObject.SetActive(newActiveState);
        quit.gameObject.SetActive(newActiveState);
    }

    private void pauseGame()
    {
        lastTimescale = Time.timeScale;
        Time.timeScale = 0.0f;
        setPauseGroupActive(true);
    }

    private void unpauseGame()
    {
        Time.timeScale = lastTimescale;
        setPauseGroupActive(false);
    }

    public void togglePauseGame()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            pauseGame();
        }
        else
        {
            unpauseGame();
        }
    }

    public void toggleInfoPanel()
    {
        isHidden = !isHidden;
    }
}
