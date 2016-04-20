﻿using UnityEngine;
using System.Collections;

public class MainUIController : MonoBehaviour {
    private PixelCanvasController pcc;
    private ScaleCanvasController scc;

	// Use this for initialization
	void Start () {
        pcc = FindObjectOfType<PixelCanvasController>();
        scc = FindObjectOfType<ScaleCanvasController>();
	}

    void Update()
    {
        handleKeyPress();
    }

    private void handleKeyPress()
    {
        if (Input.GetButtonDown("Info"))
        {
            scc.toggleInfoPanel();
        }
        if (Input.GetButtonUp("Info"))
        {
            scc.toggleInfoPanel();
        }
    }

    public void updatePlayerHealth(int remainingHealth, int maxHealth)
    {
        pcc.updatePlayerHealth(remainingHealth, maxHealth);
    }

    public void pauseGame()
    {
        scc.pauseGame();
    }

    public void unpauseGame()
    {
        scc.unpauseGame();
    }
}
